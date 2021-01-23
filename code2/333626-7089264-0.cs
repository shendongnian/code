    using System;
    using System.Linq.Expressions;
    
    class Test
    {
        static void Main()
        {
            var method = typeof (string).GetMethod("IndexOf",
                    new[] { typeof (string), typeof(StringComparison) });
    
            var left = Expression.Parameter(typeof(string), "left");
            var right = Expression.Parameter(typeof(string), "right");
            
            Expression[] parms = new Expression[] { right, 
                    Expression.Constant(StringComparison.OrdinalIgnoreCase) };
            
            var call = Expression.Call(left, method, parms);
            var lambda = Expression.Lambda<Func<string, string, int>>
                (call, left, right);
            
            var compiled = lambda.Compile();
            Console.WriteLine(compiled.Invoke("hello THERE", "lo t"));
        }
    }
