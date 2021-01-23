    public class Foo
    {
        public List<string> Strings { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Func<Foo, bool> func =
                a => a.Strings.Any(b => b == "asdf");
    
            // b => b == "asdf";
            var bParameter = Expression.Parameter(typeof (string));
            var asdfConstant = Expression.Constant("asdf");
            var compare = Expression.Equal(bParameter, asdfConstant);
            var compareExpression = Expression.Lambda<Func<string, bool>>(compare, bParameter);
            var ceCompareExpression = Expression.Constant(compareExpression.Compile());
    
            // a => a.Strings.Any(compareExpression)
            var parameter = Expression.Parameter(typeof (Foo));
    
            var foosProperty = Expression.Property(parameter, typeof (Foo).GetProperty("Strings"));
            MethodInfo method = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(string));
    
            var anyMethod = Expression.Call(method, foosProperty, ceCompareExpression);
    
            var lambdaExpression = Expression.Lambda<Func<Foo, bool>>(anyMethod, parameter);
    
            // Test.
            var foo = new Foo {Strings = new List<string> {"asdf", "fdsas"}};
    
            Console.WriteLine(string.Format("original func result: {0}", func(foo)));
            Console.Write(string.Format("constructed func result: {0}", lambdaExpression.Compile()(foo)));
    
            Console.ReadKey();
        }
    }
