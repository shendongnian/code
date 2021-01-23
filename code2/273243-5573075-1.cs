    static void UsingCompiledExpressionWithMethodCall() {
            var where = typeof(Enumerable).GetMember("Where").First() as System.Reflection.MethodInfo;
            where = where.MakeGenericMethod(typeof(int));
            var l = Expression.Parameter(typeof(IEnumerable<int>), "l");
            var arg0 = Expression.Parameter(typeof(int), "i");
            var lambda0 = Expression.Lambda<Func<int, bool>>(
                Expression.Equal(Expression.Modulo(arg0, Expression.Constant(2)),
                                 Expression.Constant(0)), arg0).Compile();
            var c1 = Expression.Call(where, l, Expression.Constant(lambda0));
            var arg1 = Expression.Parameter(typeof(int), "i");
            var lambda1 = Expression.Lambda<Func<int, bool>>(Expression.GreaterThan(arg1, Expression.Constant(5)), arg1).Compile();
            var c2 = Expression.Call(where, c1, Expression.Constant(lambda1));
            var f = Expression.Lambda<Func<IEnumerable<int>, IEnumerable<int>>>(c2, l);
            var c3 = f.Compile();
            var t0 = DateTime.Now.Ticks;
            for (int j = 1; j < MAX; j++)
            {
                var sss = c3(x).ToList();
            }
            var tn = DateTime.Now.Ticks;
            Console.WriteLine("Using lambda compiled with MethodCall: {0}", tn - t0);
        }
