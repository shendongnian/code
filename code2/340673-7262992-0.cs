    public class MyDataRowHelper
    {
        public static string GetPropertyName<T>(Expression<Func<MyDataRow, T>> expression)
        {
            MemberExpression property = (MemberExpression)expression.Body;
            return property.Member.Name;
        }
    }
