    public static MvcHtmlString CondensedHelperFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) {
    {
        var dictAttributes = htmlAttributes.ToDictionary();
        var result = new ExpandoObject();
        var d = result as IDictionary<string, object>; //work with the Expando as a Dictionary
        foreach (var pair in dictAttributes)
        {
            d[pair.Key] = pair.Value;
        }
        // Add other properties to the dictionary d here
        // ...
        var stringBuilder = new System.Text.StringBuilder();
        var tag = new TagBuilder("div"); tag.AddCssClass("some_css");
        stringBuilder.Append(toolbar.ToString(TagRenderMode.SelfClosing));
        stringBuilder.Append(htmlHelper.TextAreaFor(expression, result));
        return new MvcHtmlString(stringBuilder.ToString());
    }
