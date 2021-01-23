    public static MvcHtmlString AjaxCapableImageSubmit(this HtmlHelper html, string name, object value, string iconSrc)
    {
        // TODO: consider using a css class?
        var style = "border: none; color: transparent; cursor: pointer; " +
                    string.Format("background: url({0}) no-repeat;", iconSrc);
        var input = new TagBuilder("input");
        input.MergeAttribute("type", "submit");
        input.MergeAttribute("name", name);
        input.MergeAttribute("value", value.ToString());
        input.MergeAttribute("style", style);
        return MvcHtmlString.Create(input.ToString(TagRenderMode.SelfClosing));
    }
