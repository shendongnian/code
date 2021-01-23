    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    class Test
    {
        static void Main()
        {
            Expression<Func<string, int>> original = x => x.Length;
            var conversion = Expression.Lambda<Func<string, object>(
                  Expression.Convert(original.Body, typeof(object)),
                  original.Parameters);
            
            var conversionBack = Expression.Lambda<Func<string, int>>(
                  Expression.Convert(conversion.Body, typeof(int)),
                  original.Parameters);
            
            Console.WriteLine(conversion); // x => Convert(x.Length)
            Console.WriteLine(conversionBack); // x => Convert(Convert(x.Length))
    
            Console.WriteLine(conversion.Compile()("Hello")); // 5
            Console.WriteLine(conversionBack.Compile()("Hello")); // 5
        }
    }
