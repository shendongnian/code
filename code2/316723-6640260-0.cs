    public static class HtmlExtensions
    {
        public static MvcHtmlString MyValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors, string message)
        {
            var formContext = htmlHelper.ViewContext.ClientValidationEnabled ?  htmlHelper.ViewContext.FormContext : null;
            if (formContext == null && htmlHelper.ViewData.ModelState.IsValid)
            {
                return null;
            }
            string messageSpan;
            if (!string.IsNullOrEmpty(message))
            {
                TagBuilder spanTag = new TagBuilder("span");
                spanTag.SetInnerText(message);
                messageSpan = spanTag.ToString(TagRenderMode.Normal) + Environment.NewLine;
            }
            else
            {
                messageSpan = null;
            }
            var htmlSummary = new StringBuilder();
            TagBuilder unorderedList = new TagBuilder("ul");
            IEnumerable<ModelState> modelStates = null;
            if (excludePropertyErrors)
            {
                ModelState ms;
                htmlHelper.ViewData.ModelState.TryGetValue(htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix, out ms);
                if (ms != null)
                {
                    modelStates = new ModelState[] { ms };
                }
            }
            else
            {
                modelStates = htmlHelper.ViewData.ModelState.Values;
            }
            if (modelStates != null)
            {
                foreach (ModelState modelState in modelStates)
                {
                    foreach (ModelError modelError in modelState.Errors)
                    {
                        string errorText = GetUserErrorMessageOrDefault(htmlHelper.ViewContext.HttpContext, modelError, null /* modelState */);
                        if (!String.IsNullOrEmpty(errorText))
                        {
                            TagBuilder listItem = new TagBuilder("li");
                            listItem.InnerHtml = errorText;
                            htmlSummary.AppendLine(listItem.ToString(TagRenderMode.Normal));
                        }
                    }
                }
            }
            if (htmlSummary.Length == 0)
            {
                htmlSummary.AppendLine(@"<li style=""display:none""></li>");
            }
            unorderedList.InnerHtml = htmlSummary.ToString();
            TagBuilder divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass((htmlHelper.ViewData.ModelState.IsValid) ? HtmlHelper.ValidationSummaryValidCssClassName : HtmlHelper.ValidationSummaryCssClassName);
            divBuilder.InnerHtml = messageSpan + unorderedList.ToString(TagRenderMode.Normal);
            if (formContext != null)
            {
                // client val summaries need an ID
                divBuilder.GenerateId("validationSummary");
                formContext.ValidationSummaryId = divBuilder.Attributes["id"];
                formContext.ReplaceValidationSummary = !excludePropertyErrors;
            }
            return MvcHtmlString.Create(divBuilder.ToString());
        }
        private static string GetUserErrorMessageOrDefault(HttpContextBase httpContext, ModelError error, ModelState modelState)
        {
            if (!String.IsNullOrEmpty(error.ErrorMessage))
            {
                return error.ErrorMessage;
            }
            if (modelState == null)
            {
                return null;
            }
            string attemptedValue = (modelState.Value != null) ? modelState.Value.AttemptedValue : null;
            return String.Format(CultureInfo.CurrentCulture, "The value {0} is invalid.", attemptedValue);
        }
    }
