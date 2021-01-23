    using System;
    using System.Linq.Expressions;
    
    class Program {
        static void Main(string[] args) {
            var outerParam = Expression.Parameter(typeof(int), "outerParam");
    
            var lambda =
                Expression.Lambda<Func<int, Action>>(
                    Expression.Lambda<Action>(
                        Expression.Call(
                            typeof(Console).GetMethod("WriteLine", new Type[] { typeof(object) }),
                            Expression.Convert(outerParam, typeof(object))
                        )
                    ),
                    outerParam
                ).Compile();
    
            var actionParam = Expression.Parameter(typeof(Action), "action");
            var lambdaInvoker =
                Expression.Lambda<Action<Action>>(
                    Expression.Invoke(actionParam),
                    actionParam
                ).Compile();
    
            lambdaInvoker(lambda(100));
            lambdaInvoker(lambda(200));
            Console.ReadLine();
        }
    }
