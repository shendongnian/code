    public static MvcHtmlString ValidationSummary(this HtmlHelper htmlHelper, string[] includePropertyErrors)
    {
        return ValidationSummary(htmlHelper, includePropertyErrors, null, null);
    }
    public static MvcHtmlString ValidationSummary(this HtmlHelper htmlHelper, string[] includePropertyErrors, string message)
    {
        return ValidationSummary(htmlHelper, includePropertyErrors, message, null);
    }
    public static MvcHtmlString ValidationSummary(this HtmlHelper htmlHelper, string[] includePropertyErrors, string message, IDictionary<string, object> htmlAttributes)
    {
        if (htmlHelper == null)
        {
            throw new ArgumentNullException("htmlHelper");
        }
        FormContext formContext = htmlHelper.ViewContext.ClientValidationEnabled ? htmlHelper.ViewContext.FormContext : null;
        if (htmlHelper.ViewData.ModelState.IsValid)
        {
            if (formContext == null)
            {  // No client side validation
                return null;
            }
            // TODO: This isn't really about unobtrusive; can we fix up non-unobtrusive to get rid of this, too?
            if (htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
            {  // No client-side updates
                return null;
            }
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
        StringBuilder htmlSummary = new StringBuilder();
        TagBuilder unorderedList = new TagBuilder("ul");
        IEnumerable<ModelState> modelStates = from ms in htmlHelper.ViewData.ModelState
                                                where ms.Key == htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix ||
                                                    includePropertyErrors.Any(property =>
                                                    {
                                                        string prefixedProperty = string.IsNullOrEmpty(htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix) ? property : htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix + "." + property;
                                                        if (property.EndsWith("[]"))
                                                        {
                                                            return prefixedProperty.Substring(0, property.Length - 2) == Regex.Replace(ms.Key, @"\[[^\]]+\]", string.Empty);
                                                        }
                                                        else
                                                        {
                                                            return property == ms.Key;
                                                        }
                                                    })
                                                select ms.Value;
        if (modelStates != null)
        {
            foreach (ModelState modelState in modelStates)
            {
                foreach (ModelError modelError in modelState.Errors)
                {
                    string errorText = GetUserErrorMessageOrDefault(htmlHelper.ViewContext.HttpContext, modelError);
                    if (!String.IsNullOrEmpty(errorText))
                    {
                        TagBuilder listItem = new TagBuilder("li");
                        listItem.SetInnerText(errorText);
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
        divBuilder.MergeAttributes(htmlAttributes);
        divBuilder.AddCssClass((htmlHelper.ViewData.ModelState.IsValid) ? HtmlHelper.ValidationSummaryValidCssClassName : HtmlHelper.ValidationSummaryCssClassName);
        divBuilder.InnerHtml = messageSpan + unorderedList.ToString(TagRenderMode.Normal);
        if (formContext != null)
        {
            if (!htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
            {
                // client val summaries need an ID
                divBuilder.GenerateId("validationSummary");
                formContext.ValidationSummaryId = divBuilder.Attributes["id"];
                formContext.ReplaceValidationSummary = false;
            }
        }
        return new MvcHtmlString(divBuilder.ToString(TagRenderMode.Normal));
    }
    private static string GetUserErrorMessageOrDefault(HttpContextBase httpContext, ModelError error)
    {
        return string.IsNullOrEmpty(error.ErrorMessage) ? null : error.ErrorMessage;
    }
