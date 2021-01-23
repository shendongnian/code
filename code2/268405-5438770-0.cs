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
        public static string GetPropertyName<TObject>(Expression<Func<TObject, object>> p)
        {
            return GetPropertyNameInternal(p);
        }
        public static string GetPropertyName<TObject, T>(Expression<Func<TObject, T>> p)
        {
            return GetPropertyNameInternal(p);
        }
        public static string GetPropertyName<T>(Expression<Func<T>> p)
        {
            return GetPropertyNameInternal(p);
        }
        public static string GetPropertyName(Expression p)
        {
            return GetPropertyNameInternal((LambdaExpression) p);
        }
        private static string GetPropertyNameInternal(LambdaExpression p)
        {
            return GetPropertyInternal(p).Name;
        }
        public static PropertyInfo GetProperty<TObject>(Expression<Func<TObject, object>> p)
        {
            return GetPropertyInternal(p);
        }
        public static PropertyInfo GetProperty<TObject, T>(Expression<Func<TObject, T>> p)
        {
            return GetPropertyInternal(p);
        }
        public static PropertyInfo GetProperty<T>(Expression<Func<T>> p)
        {
            return GetPropertyInternal(p);
        }
    }
