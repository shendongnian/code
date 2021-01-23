    using System;
    using System.Linq.Expressions;
    
    class Test
    {
        static string someValue;
        
        static void Main()
        {
            someValue = "target value";
            
            DisplayCallTarget(() => someValue.Replace("x", "y"));
        }
        
        static void DisplayCallTarget(Expression<Action> action)
        {
            // TODO: *Lots* of validation
            MethodCallExpression call = (MethodCallExpression) action.Body;
            
            LambdaExpression targetOnly = Expression.Lambda(call.Object, null);
            Delegate compiled = targetOnly.Compile();
            object result = compiled.DynamicInvoke(null);
            Console.WriteLine(result);
        }
    }
