    static class TestExtensions
    {
        public static string Property<TModel, TProperty>(this TModel test, Expression<Func<TModel, TProperty>> property)
        {
            return property.ToString();
        }
    }
