    class ModelBase<TModel>
    {
        public virtual IDictionary<string, object> GetHtmlAttributes<TProperty>
            (Expression<Func<TModel, TProperty>> propertyExpression)
        {
            return new Dictionary<string, object>();
        }
    }
    class FooModel : ModelBase<FooModel>
    {
        public override IDictionary<string, object> GetHtmlAttributes<TProperty>
            (Expression<Func<FooModel, TProperty>> propertyExpression)
        {
            return new Dictionary<string, object> { { "foo", "bar" } };
        }
    }
