    public static MvcHtmlString LabelFor<TModel, TValue>(
        this HtmlHelper<TModel> self, 
        Expression<Func<TModel, TValue>> expression, 
        bool showToolTip
    )
    {
        var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
        var description = metadata.Description; // will equal "some description"
        var name = metadata.DisplayName; // will equal "some name"
        // TODO: do something with the name and the description
        ...
    }
