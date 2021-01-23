    public class MyDataRowHelper
    {
        public static string GetMemberName<T>(Expression<Func<MyDataRow, T>> expression)
        {
            MemberExpression member = (MemberExpression)expression.Body;
            return member.Member.Name;
        }
    }
