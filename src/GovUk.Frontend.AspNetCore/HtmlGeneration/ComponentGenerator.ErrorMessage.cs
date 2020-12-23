#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUk.Frontend.AspNetCore.HtmlGeneration
{
    public partial class ComponentGenerator
    {
        internal const string ErrorMessageElement = "span";
        internal const string ErrorMessageDefaultVisuallyHiddenText = "Error";

        public TagBuilder GenerateErrorMessage(
            string visuallyHiddenText,
            IHtmlContent content,
            IDictionary<string, string> attributes)
        {
            Guard.ArgumentNotNull(nameof(content), content);

            var tagBuilder = new TagBuilder(ErrorMessageElement);
            tagBuilder.MergeAttributes(attributes);
            tagBuilder.MergeCssClass("govuk-error-message");

            if (!string.IsNullOrEmpty(visuallyHiddenText))
            {
                var vht = new TagBuilder("span");
                vht.MergeCssClass("govuk-visually-hidden");
                vht.InnerHtml.Append(visuallyHiddenText + ":");

                tagBuilder.InnerHtml.AppendHtml(vht);
            }

            tagBuilder.InnerHtml.AppendHtml(content);

            return tagBuilder;
        }
    }
}
