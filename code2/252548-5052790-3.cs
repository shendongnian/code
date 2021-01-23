    public static class ExtensionMethods
    {
        public static MvcHtmlString StateDropDownList<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>>)
        {
            return html.TextBoxFor(expression, new { @class = "foo" });
        }
    }
