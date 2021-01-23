    public class AttributeTester
    {
        public Attribute[] Attributes { get; set; }
        public void ImplementsAttribute<TAttType>()
        {
             Assert.IsTrue(Attributes.Any(x => x is TAttType));
        }
    }
    public static void ForProperty<TType, TProperty>(this TType obj, Expression<Func<TType, TProperty>> expression)
    {
         var memberExpression = expression.Body as MemberExpression;
         var name = MetaHelper.GetPropertyName(expression);
         var property = memberExpression.Expression.Type.GetProperty(name);
         return new AttributeTester { Attributes = property.GetCustomAttributes(true) };
    }
