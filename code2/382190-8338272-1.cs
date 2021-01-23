    public class Person
    {
        public string Name { get; set; }
    }
    public static class StringEx
    {
        public static bool Like(this string a, string b)
        {
            return a.ToLower().Contains(b.ToLower());
        }
    }
    Person p = new Person(){Name = "Me"};
    var prop = Expression.Property(Expression.Constant(p), "Name");
    var value = Expression.Constant("me");
    var like = typeof(StringEx).GetMethod("Like", BindingFlags.Static
                            | BindingFlags.Public | BindingFlags.NonPublic);
    var comparer = Expression.Call(null, like, prop, value );
    
    var vvv = (Func<bool>) Expression.Lambda(comparer).Compile();
    bool isEquals = vvv.Invoke();
