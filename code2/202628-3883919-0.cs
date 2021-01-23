    namespace ConsoleApplication2
    {
        using System;
        using System.Linq.Expressions;
        class Program
        {
            static void Main(string[] args)
            {
                string fullName = GetExpression(() => SomeClass.SomeProperty);
                Console.WriteLine(fullName);
            }
            public static string GetExpression<TProperty>(Expression<Func<TProperty>> expr)
            {
                string name = expr.Body.ToString();
                string value = expr.Compile().Invoke().ToString();
                name = name.Substring(0, name.LastIndexOf(".") + 1) + value;
                return name;
            }
        }
        public static class SomeClass
        {
            public static string SomeProperty = "Hello";
        }
    }
