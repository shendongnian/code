	public static IHtmlContent DescriptionFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
	{
		if (html == null) throw new ArgumentNullException(nameof(html));
		if (expression == null) throw new ArgumentNullException(nameof(expression));
		var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
		if (modelExplorer == null) throw new InvalidOperationException($"Failed to get model explorer for {ExpressionHelper.GetExpressionText(expression)}");
        var metadata = (DefaultModelMetadata)modelExplorer?.Metadata;
            
        if (metadata == null)
        {
            return new HtmlString(string.Empty);
        }
        var text = (metadata
                    .Attributes
                    .Attributes // yes, twice
                    .FirstOrDefault(x => x.GetType() == typeof(DescriptionAttribute)) as DescriptionAttribute)
                    ?.Description;
        return new HtmlString(text ?? string.Empty);
	}
