    public static MvcHtmlString RequiredSymbolFor<TModel, TProperty>(
        this HtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression,
        string symbol = "*",
        string cssClass = "editor-field-required")
    {
        ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
 
        if (modelMetadata.IsRequired)
        {
            var builder = new TagBuilder("span");
            builder.AddCssClass(cssClass);
            builder.InnerHtml = symbol;
 
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }
 
        return new MvcHtmlString("");
    }
