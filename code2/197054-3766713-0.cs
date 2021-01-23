    using System;
    using System.Linq.Expressions;
    
    class Foo
    {
        public void Save(int x, string y)
        {
        }
    }
    
    class Program
    {
        static void Main()
        {
            ShowValues<Foo>(x => x.Save(1, "Jimmy"));
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
                var constant = argument as ConstantExpression;
                if (constant == null)
                {
                    throw new ArgumentException("Argument wasn't a constant");
                }
                Console.WriteLine("Got argument: {0}", constant.Value);
            }
        }
    }
