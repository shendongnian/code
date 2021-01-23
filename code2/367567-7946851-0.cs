    namespace MyCMS.Helpers
    {
    public static class Html
    {
        public static MvcHtmlString DescriptionFor<TModel, TValue>(
            this HtmlHelper<TModel> self, 
            Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            var description = Localizer.Translate(metadata.Description);
            return MvcHtmlString.Create(string.Format(@"<span class=""help-block"">{0}</span>", description));
        }
        public static MvcHtmlString LabelFor<TModel, TValue>(
            this HtmlHelper<TModel> self, 
            Expression<Func<TModel, TValue>> expression, 
            bool showToolTip
        )
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            var name = Localizer.Translate(metadata.DisplayName);
            return MvcHtmlString.Create(string.Format(@"<label for=""{0}"">{1}</label>", metadata.PropertyName, name));
        }
    }
    }
