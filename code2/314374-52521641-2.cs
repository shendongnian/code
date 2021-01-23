    public static class MvcHtmlHelpers
    {
        public static string DescriptionFor<TModel, TValue>(this HtmlHelper<TModel> self, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            var description = metadata.Description;
            return string.IsNullOrWhiteSpace(description) ? "" : description;
        }
    }
