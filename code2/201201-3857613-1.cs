    public static MvcHtmlString AjaxCapableImageSubmit(this HtmlHelper html, string name, object value, string iconSrc, string cssClass = null, string onClick = null)
    {
        var style = string.Format("background: url({0}) no-repeat;", iconSrc);
        var input = new TagBuilder("input");
        input.AddCssClass("image-submit-button");
        input.MergeAttribute("type", "submit");
        input.MergeAttribute("name", name);
        input.MergeAttribute("value", value.ToString());
        input.MergeAttribute("style", style);
        if (cssClass != null) input.AddCssClass(cssClass);
        if (onClick != null) input.MergeAttribute("onclick", onClick);
        return MvcHtmlString.Create(input.ToString(TagRenderMode.SelfClosing));
    }
