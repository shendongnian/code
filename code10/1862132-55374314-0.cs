    public static class HtmlHelpers
    {
        public static IHtmlContent DescriptionFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
    
            DescriptionAttribute descriptionAttribute = null;
            if (expression.Body is MemberExpression memberExpression)
            {
                descriptionAttribute = memberExpression.Member
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .Cast<DescriptionAttribute>()
                    .SingleOrDefault();
            }
    
            return new HtmlString(descriptionAttribute == null ? "" : descriptionAttribute.Description);
        }
    }
