    static class ModelExtensions
    {
        public static IDictionary<string, object> GetHtmlAttributes<TModel, TProperty>
            (this TModel model, Expression<Func<TModel, TProperty>> propertyExpression)
        {
            return new Dictionary<string, object>();
        }
    }
