    public static MvcHtmlString ValidationSummaryForSubModel(this HtmlHelper html, bool excludePropertyErrors, string message, IDictionary<string, object> htmlAttributes)
		{
			string prefix = html.ViewData.TemplateInfo.HtmlFieldPrefix;
			var props = html.ViewData.ModelState.Where(x => x.Key.StartsWith(prefix));
			var errorprops = props.Where(x => x.Value.Errors.Any()).SelectMany(x=>x.Value.Errors);
			
			if (html == null) {
                throw new ArgumentNullException("html");
            }
			FormContext formContext = (html.ViewContext.ClientValidationEnabled) ? html.ViewContext.FormContext : null;
			if (formContext == null && html.ValidForSubModel())
			{
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
            
            foreach (ModelError modelError in errorprops) {
                string errorText = GetUserErrorMessageOrDefault(html.ViewContext.HttpContext, modelError, null /* modelState */);
                if (!String.IsNullOrEmpty(errorText)) {
                    TagBuilder listItem = new TagBuilder("li");
                    listItem.SetInnerText(errorText);
                    htmlSummary.AppendLine(listItem.ToString(TagRenderMode.Normal));
                }
            }
         
            if (htmlSummary.Length == 0) {
                htmlSummary.AppendLine(_hiddenListItem);
            }
            unorderedList.InnerHtml = htmlSummary.ToString();
            TagBuilder divBuilder = new TagBuilder("div");
            divBuilder.MergeAttributes(htmlAttributes);
			divBuilder.AddCssClass((html.ViewData.ModelState.IsValid) ? HtmlHelper.ValidationSummaryValidCssClassName : HtmlHelper.ValidationSummaryCssClassName);
            divBuilder.InnerHtml = messageSpan + unorderedList.ToString(TagRenderMode.Normal);
            if (formContext != null) {
                // client val summaries need an ID
                divBuilder.GenerateId("validationSummary");
                formContext.ValidationSummaryId = divBuilder.Attributes["id"];
                formContext.ReplaceValidationSummary = !excludePropertyErrors;
            }
            return MvcHtmlString.Create(divBuilder.ToString(TagRenderMode.Normal));
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
			//return String.Format(CultureInfo.CurrentCulture, GetInvalidPropertyValueResource(httpContext), attemptedValue);
			return "Error";
		}
