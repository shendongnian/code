        public static MvcHtmlString HiddenForInvariant<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var id = string.Format("{0}", metadata.PropertyName);
            var compile = expression.Compile();
            string value = Convert.ToString(compile(htmlHelper.ViewData.Model), CultureInfo.InvariantCulture);
            var hidden = htmlHelper.Hidden(id, value).ToHtmlString();
            return new MvcHtmlString(hidden);
        }
