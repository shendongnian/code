    public static MvcHtmlString DescriptionFor<TModel, TValue>(
        this HtmlHelper<TModel> self, 
        Expression<Func<TModel, TValue>> expression
    )
    {
        var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
        var description = metadata.Description; // will equal "Your secreet password"
        var name = metadata.DisplayName; // will equal "Password"
        // TODO: do something with the name and the description
        ...
    }
