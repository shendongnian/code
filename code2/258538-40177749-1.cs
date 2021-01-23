    public static class UploadHelper
    {
    public static MvcHtmlString UploadFile(this HtmlHelper helper, string name, object htmlAttributes = null)
    {
        TagBuilder input = new TagBuilder("input");
        input.Attributes.Add("type", "file");
        input.Attributes.Add("id", helper.ViewData.TemplateInfo.GetFullHtmlFieldId(name));
        input.Attributes.Add("name", helper.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
        if (htmlAttributes != null)
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            input.MergeAttributes(attributes);
        }
        return new MvcHtmlString(input.ToString());
       }
    }
