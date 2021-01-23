    public static MvcHtmlString FooBarFor<TModel, TProperty>(
        this HtmlHelper<TModel> htmlHelper, 
        Expression<Func<TModel, TProperty>> expression
    ) 
    {
        var name = ExpressionHelper.GetExpressionText(expression);
        var fullHtmlFieldName = htmlHelper
            .ViewContext
            .ViewData
            .TemplateInfo
            .GetFullHtmlFieldName(name);
        // do something with the name
        ...
    }
