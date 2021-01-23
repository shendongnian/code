    using System;
    using System.Linq.Expressions;
    
    class Foo
    {
        public void Save(int x, string y, int z, double d)
        {
        }
    }
    
    class Program
    {
        static void Main()
        {
            var x = 1;
            var a = 2;
            var b = 3;
            ShowValues<Foo>(o => o.Save(x, "Jimmy", a + b + 5, Math.Sqrt(81)));
        }
    
        static void ShowValues<T>(Expression<Action<T>> expression)
        {
            var call = expression.Body as MethodCallExpression;
            if (call == null)
            {
                throw new ArgumentException("Not a method call");
            }
            foreach (Expression argument in call.Arguments)
            {
                LambdaExpression lambda = Expression.Lambda(argument, 
                                                            expression.Parameters);
                Delegate d = lambda.Compile();
                object value = d.DynamicInvoke(new object[1]);
                Console.WriteLine("Got value: {0}", value);
            }
        }
    }
