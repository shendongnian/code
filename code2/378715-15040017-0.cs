    public static IHtmlString SomeHelperMethod<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty> propertyExpression)
    {
        var propertyName = html.NameFor(propertyExpression).ToString();
        var metadata = ModelMetadata.FromLambdaExpression(propertyExpression, html.ViewData);
        var attributes = html.GetUnobtrusiveValidationAttributes(propertyName, metadata);
    }
