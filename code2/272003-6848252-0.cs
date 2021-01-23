    private static TagBuilder CreateHiddenTag(string inputName, object value, 
            object htmlAttributes)
    {
        var tagBuilder = new TagBuilder("input");
        tagBuilder.MergeAttribute("type", "hidden");
        tagBuilder.MergeAttribute("name", inputName);
        tagBuilder.GenerateId(inputName);
        if (value != null)
            tagBuilder.MergeAttribute("value", value.ToString());
        if (htmlAttributes != null)
            tagBuilder.MergeAttributes(
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), 
                replaceExisting: true);
        return tagBuilder;
    }
