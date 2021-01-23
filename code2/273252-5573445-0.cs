    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using System.Linq.Expressions;
    namespace ExpressionBench
    {
        class Program
        {
            static void Main(string[] args)
            {
                var values = Enumerable.Range(0, 100);
                var lambda = Lambda();
                var lambdaExpression = LambdaExpression();
                var handMadeLambdaExpression = HandMadeLambdaExpression();
                DoTest("Lambda", values, lambda);
                DoTest("Lambda Expression", values, lambdaExpression.Compile());
                DoTest("Hand Made Lambda Expression", values, handMadeLambdaExpression.Compile());
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
                Console.WriteLine();
            }
            static void DoTest<TInput, TOutput>(string name, TInput sequence, Func<TInput, TOutput> operation, int count = 1000000)
            {
                for (int _ = 0; _ < 1000; _++)
                    operation(sequence);
                var sw = Stopwatch.StartNew();
                for (int _ = 0; _ < count; _++)
                    operation(sequence);
                sw.Stop();
                Console.WriteLine("{0}:", name);
                Console.WriteLine("  Elapsed: {0,10} {1,10} (ms)", sw.ElapsedTicks, sw.ElapsedMilliseconds);
                Console.WriteLine("  Average: {0,10} {1,10} (ms)", decimal.Divide(sw.ElapsedTicks, count), decimal.Divide(sw.ElapsedMilliseconds, count));
            }
            static Func<IEnumerable<int>, IList<int>> Lambda()
            {
                return v => v.Where(i => i % 2 == 0).Where(i => i > 5).ToList();
            }
            static Expression<Func<IEnumerable<int>, IList<int>>> LambdaExpression()
            {
                return v => v.Where(i => i % 2 == 0).Where(i => i > 5).ToList();
            }
            static Expression<Func<IEnumerable<int>, IList<int>>> HandMadeLambdaExpression()
            {
                var enumerableMethods = typeof(Enumerable).GetMethods();
                var whereMethod = enumerableMethods
                    .Where(m => m.Name == "Where")
                    .Select(m => m.MakeGenericMethod(typeof(int)))
                    .Where(m => m.GetParameters()[1].ParameterType == typeof(Func<int, bool>))
                    .Single();
                var toListMethod = enumerableMethods
                    .Where(m => m.Name == "ToList")
                    .Select(m => m.MakeGenericMethod(typeof(int)))
                    .Single();
                // helpers to create the static method call expressions
                Func<Expression, ParameterExpression, Func<ParameterExpression, Expression>, Expression> WhereExpression =
                    (instance, param, body) => Expression.Call(null, whereMethod, instance, Expression.Lambda(body(param), param));
                Func<Expression, Expression> ToListExpression =
                    instance => Expression.Call(null, toListMethod, instance);
                //return v => v.Where(i => i % 2 == 0).Where(i => i > 5).ToList();
                var exprParam = Expression.Parameter(typeof(IEnumerable<int>), "v");
                var expr0 = WhereExpression(
                    exprParam,
                    Expression.Parameter(typeof(int), "i"),
                    p => Expression.Equal(Expression.Modulo(p, Expression.Constant(2)), Expression.Constant(0)));
                var expr1 = WhereExpression(
                    expr0,
                    Expression.Parameter(typeof(int), "i"),
                    p => Expression.GreaterThan(p, Expression.Constant(5)));
                var exprBody = ToListExpression(expr1);
                return Expression.Lambda<Func<IEnumerable<int>, IList<int>>>(exprBody, exprParam);
            }
        }
    }
