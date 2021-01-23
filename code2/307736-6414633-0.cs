    public class Entity<T> where T : class
    {
        public static string GetName(Expression<Func<T, object>> expr)
        {
            return ((MemberExpression)expr.Body).Member.Name;
        }
    }
    public class User: Entity<User>
    {
        public String UserName { get; set; }
    }
