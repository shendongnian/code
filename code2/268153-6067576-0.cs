    class Program
        {
            static void Main(string[] args)
            {
                Expression<Action<string>> action = a => Console.WriteLine("asdf");
                var mce = action.Body as MethodCallExpression;
                Console.WriteLine((mce.Arguments[0] as ConstantExpression).Value);
                Console.ReadKey();
            }
        }
