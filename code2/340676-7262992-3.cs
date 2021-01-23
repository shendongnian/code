    public class MyDataRowHelper
    {
        public static string GetMemberName<T>(Expression<Func<MyDataRow, T>> expression)
        {
            MemberExpression member = expression.Body as MemberExpression;
            if(member != null)
                return member.Member.Name;
            throw new InvalidOperationException("Member expression expected");
        }
    }
