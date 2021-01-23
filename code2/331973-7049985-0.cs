        public static string ValidationSummary(this HtmlHelper htmlHelper, string message, IDictionary<string, object> htmlAttributes) {
            // Nothing to do if there aren't any errors
            if (htmlHelper.ViewData.ModelState.IsValid) {
                return null;
            }
            string messageSpan;
            if (!String.IsNullOrEmpty(message)) {
                TagBuilder spanTag = new TagBuilder("span");
                spanTag.MergeAttributes(htmlAttributes);
                spanTag.MergeAttribute("class", HtmlHelper.ValidationSummaryCssClassName);
                spanTag.SetInnerText(message);
                messageSpan = spanTag.ToString(TagRenderMode.Normal) + Environment.NewLine;
            }
            else {
                messageSpan = null;
            }
            StringBuilder htmlSummary = new StringBuilder();
            TagBuilder unorderedList = new TagBuilder("ul");
            unorderedList.MergeAttributes(htmlAttributes);
            unorderedList.MergeAttribute("class", HtmlHelper.ValidationSummaryCssClassName);
            foreach (ModelState modelState in htmlHelper.ViewData.ModelState.Values) {
                foreach (ModelError modelError in modelState.Errors) {
                    string errorText = GetUserErrorMessageOrDefault(htmlHelper.ViewContext.HttpContext, modelError, null /* modelState */);
                    if (!String.IsNullOrEmpty(errorText)) {
                        TagBuilder listItem = new TagBuilder("li");
                        listItem.SetInnerText(errorText);
                        htmlSummary.AppendLine(listItem.ToString(TagRenderMode.Normal));
                    }
                }
            }
            unorderedList.InnerHtml = htmlSummary.ToString();
            return messageSpan + unorderedList.ToString(TagRenderMode.Normal);
        }
