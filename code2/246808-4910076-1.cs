    public static IHtmlString TooltipFor<TModel, TValue>(this HtmlHelper<TModel> self, Expression<Func<TModel, TValue>> expression)
    {
        var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            
        var span = new TagBuilder("span");
        span.Attributes.Add("title", metadata.Description);
        span.Attributes.Add("class", "tooltip");
        span.SetInnerText(metadata.DisplayName);
        return MvcHtmlString.Create(span.ToString());
    }
