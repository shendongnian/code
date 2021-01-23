    public class TypeHelper
    {
        private static PropertyInfo GetPropertyInternal(LambdaExpression p)
        {
            MemberExpression memberExpression;
            if (p.Body is UnaryExpression)
            {
                UnaryExpression ue = (UnaryExpression)p.Body;
                memberExpression = (MemberExpression)ue.Operand;
            }
            else
            {
                memberExpression = (MemberExpression)p.Body;
            }
            return (PropertyInfo)(memberExpression).Member;
        }
        public static PropertyInfo GetProperty<TObject>(Expression<Func<TObject, object>> p)
        {
            return GetPropertyInternal(p);
        }
    }
