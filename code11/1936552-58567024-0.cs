    public class MyModel
    {
        public string FirstName { get { return "John Jacob Jingleheimer Schmidt"; } }
    }
	
    public class Program
    {
        public static void Main()
        {
            var model = new MyModel();
            var result = Test(m => m.FirstName, model);
            Console.WriteLine(result);
        }
        public static TOut Test<TIn, TOut>(Expression<Func<TIn, TOut>> expression, TIn instance) where TOut: class
        {
            MemberExpression memberExpression = (MemberExpression)expression.Body;
            var member = memberExpression.Member;
            Console.WriteLine("The expression is a reference to '{0}.{1}'", member.DeclaringType.FullName, member.Name);
            var compiled = expression.Compile();
            var result = compiled(instance) as TOut;
            return result;
        }
    }
