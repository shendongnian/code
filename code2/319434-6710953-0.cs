    public static MvcHtmlString PaginationFor<TModel, TProperty>(
        this HtmlHelper<TModel> html,
        Expression<Func<TModel, TProperty>> expression
    )
    {
        TModel model = html.ViewData.Model;
        var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
        var propertyValue = metaData.Model; // This will be of type TProperty
        return html.Partial("View", propertyValue);
    }
