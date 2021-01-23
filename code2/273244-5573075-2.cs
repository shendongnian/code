    static void UsingCompiledConstantExpressions() {
        var f1 = (Func<IEnumerable<int>, IEnumerable<int>>)(l => l.Where(i => i % 2 == 0));
        var f2 = (Func<IEnumerable<int>, IEnumerable<int>>)(l => l.Where(i => i > 5));
        var argX = Expression.Parameter(typeof(IEnumerable<int>), "x");
        var f3 = Expression.Invoke(Expression.Constant(f2), Expression.Invoke(Expression.Constant(f1), argX));
        var f = Expression.Lambda<Func<IEnumerable<int>, IEnumerable<int>>>(f3, argX);
        var c3 = f.Compile();
        var t0 = DateTime.Now.Ticks;
        for (int j = 1; j < MAX; j++) {
            var sss = c3(x).ToList();
        }
        var tn = DateTime.Now.Ticks;
        Console.WriteLine("Using lambda compiled constant: {0}", tn - t0);
    }
