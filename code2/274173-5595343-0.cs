    public static MvcHtmlString ValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors, string message, IDictionary<string, object> htmlAttributes) {
            if (htmlHelper == null) {
                throw new ArgumentNullException("htmlHelper");
            }
            FormContext formContext = htmlHelper.ViewContext.GetFormContextForClientValidation();
            if (formContext == null && htmlHelper.ViewData.ModelState.IsValid) {
                return null;
            }
            string messageSpan;
            if (!String.IsNullOrEmpty(message)) {
                TagBuilder spanTag = new TagBuilder("span");
                spanTag.SetInnerText(message);
                messageSpan = spanTag.ToString(TagRenderMode.Normal) + Environment.NewLine;
            }
            else {
                messageSpan = null;
            }
            StringBuilder htmlSummary = new StringBuilder();
            TagBuilder unorderedList = new TagBuilder("ul");
            IEnumerable<ModelState> modelStates = null;
            if (excludePropertyErrors) {
                ModelState ms;
                htmlHelper.ViewData.ModelState.TryGetValue(htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix, out ms);
                if (ms != null) {
                    modelStates = new ModelState[] { ms };
                }
            }
            else {
                modelStates = htmlHelper.ViewData.ModelState.Values;
            }
            if (modelStates != null) {
                foreach (ModelState modelState in modelStates) {
                    foreach (ModelError modelError in modelState.Errors) {
                        string errorText = GetUserErrorMessageOrDefault(htmlHelper.ViewContext.HttpContext, modelError, null /* modelState */);
                        if (!String.IsNullOrEmpty(errorText)) {
                            TagBuilder listItem = new TagBuilder("li");
                            listItem.SetInnerText(errorText);
                            htmlSummary.AppendLine(listItem.ToString(TagRenderMode.Normal));
                        }
                    }
                }
            }
            if (htmlSummary.Length == 0) {
                htmlSummary.AppendLine(_hiddenListItem);
            }
            unorderedList.InnerHtml = htmlSummary.ToString();
            TagBuilder divBuilder = new TagBuilder("div");
            divBuilder.MergeAttributes(htmlAttributes);
            divBuilder.AddCssClass((htmlHelper.ViewData.ModelState.IsValid) ? HtmlHelper.ValidationSummaryValidCssClassName : HtmlHelper.ValidationSummaryCssClassName);
            divBuilder.InnerHtml = messageSpan + unorderedList.ToString(TagRenderMode.Normal);
            if (formContext != null) {
                // client val summaries need an ID
                divBuilder.GenerateId("validationSummary");
                formContext.ValidationSummaryId = divBuilder.Attributes["id"];
                formContext.ReplaceValidationSummary = !excludePropertyErrors;
            }
            return divBuilder.ToMvcHtmlString(TagRenderMode.Normal);
        }
