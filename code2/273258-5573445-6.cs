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
                var values = Enumerable.Range(0, 2000);
                var lambda = GetLambda();
                var lambdaExpression = GetLambdaExpression().Compile();
                var handMadeLambdaExpression = GetHandMadeLambdaExpression().Compile();
                var composed = GetComposed();
                var composedExpression = GetComposedExpression().Compile();
                var handMadeComposedExpression = GetHandMadeComposedExpression().Compile();
                DoTest("Lambda", values, lambda);
                DoTest("Lambda Expression", values, lambdaExpression);
                DoTest("Hand Made Lambda Expression", values, handMadeLambdaExpression);
                Console.WriteLine();
                DoTest("Composed", values, composed);
                DoTest("Composed Expression", values, composedExpression);
                DoTest("Hand Made Composed Expression", values, handMadeComposedExpression);
            }
            static void DoTest<TInput, TOutput>(string name, TInput sequence, Func<TInput, TOutput> operation, int count = 100000)
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
            static Func<IEnumerable<int>, IList<int>> GetLambda()
            {
                return v => v.Where(i => i % 2 == 0).Where(i => i > 5).ToList();
            }
            static Expression<Func<IEnumerable<int>, IList<int>>> GetLambdaExpression()
            {
                return v => v.Where(i => i % 2 == 0).Where(i => i > 5).ToList();
            }
            static Expression<Func<IEnumerable<int>, IList<int>>> GetHandMadeLambdaExpression()
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
                    (instance, param, body) => Expression.Call(whereMethod, instance, Expression.Lambda(body(param), param));
                Func<Expression, Expression> ToListExpression =
                    instance => Expression.Call(toListMethod, instance);
                //return v => v.Where(i => i % 2 == 0).Where(i => i > 5).ToList();
                var exprParam = Expression.Parameter(typeof(IEnumerable<int>), "v");
                var expr0 = WhereExpression(exprParam,
                    Expression.Parameter(typeof(int), "i"),
                    i => Expression.Equal(Expression.Modulo(i, Expression.Constant(2)), Expression.Constant(0)));
                var expr1 = WhereExpression(expr0,
                    Expression.Parameter(typeof(int), "i"),
                    i => Expression.GreaterThan(i, Expression.Constant(5)));
                var exprBody = ToListExpression(expr1);
                return Expression.Lambda<Func<IEnumerable<int>, IList<int>>>(exprBody, exprParam);
            }
            static Func<IEnumerable<int>, IList<int>> GetComposed()
            {
                Func<IEnumerable<int>, IEnumerable<int>> composed0 =
                    v => v.Where(i => i % 2 == 0);
                Func<IEnumerable<int>, IEnumerable<int>> composed1 =
                    v => v.Where(i => i > 5);
                Func<IEnumerable<int>, IList<int>> composed2 =
                    v => v.ToList();
                return v => composed2(composed1(composed0(v)));
            }
            static Expression<Func<IEnumerable<int>, IList<int>>> GetComposedExpression()
            {
                Expression<Func<IEnumerable<int>, IEnumerable<int>>> composed0 =
                    v => v.Where(i => i % 2 == 0);
                Expression<Func<IEnumerable<int>, IEnumerable<int>>> composed1 =
                    v => v.Where(i => i > 5);
                Expression<Func<IEnumerable<int>, IList<int>>> composed2 =
                    v => v.ToList();
                var exprParam = Expression.Parameter(typeof(IEnumerable<int>), "v");
                var exprBody = Expression.Invoke(composed2, Expression.Invoke(composed1, Expression.Invoke(composed0, exprParam)));
                return Expression.Lambda<Func<IEnumerable<int>, IList<int>>>(exprBody, exprParam);
            }
            static Expression<Func<IEnumerable<int>, IList<int>>> GetHandMadeComposedExpression()
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
                Func<ParameterExpression, Func<ParameterExpression, Expression>, Expression> LambdaExpression =
                    (param, body) => Expression.Lambda(body(param), param);
                Func<Expression, ParameterExpression, Func<ParameterExpression, Expression>, Expression> WhereExpression =
                    (instance, param, body) => Expression.Call(whereMethod, instance, Expression.Lambda(body(param), param));
                Func<Expression, Expression> ToListExpression =
                    instance => Expression.Call(toListMethod, instance);
                var composed0 = LambdaExpression(Expression.Parameter(typeof(IEnumerable<int>), "v"),
                    v => WhereExpression(
                        v,
                        Expression.Parameter(typeof(int), "i"),
                        i => Expression.Equal(Expression.Modulo(i, Expression.Constant(2)), Expression.Constant(0))));
                var composed1 = LambdaExpression(Expression.Parameter(typeof(IEnumerable<int>), "v"),
                    v => WhereExpression(
                        v,
                        Expression.Parameter(typeof(int), "i"),
                        i => Expression.GreaterThan(i, Expression.Constant(5))));
                var composed2 = LambdaExpression(Expression.Parameter(typeof(IEnumerable<int>), "v"),
                    v => ToListExpression(v));
                var exprParam = Expression.Parameter(typeof(IEnumerable<int>), "v");
                var exprBody = Expression.Invoke(composed2, Expression.Invoke(composed1, Expression.Invoke(composed0, exprParam)));
                return Expression.Lambda<Func<IEnumerable<int>, IList<int>>>(exprBody, exprParam);
            }
        }
    }
