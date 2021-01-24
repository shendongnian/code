    // The expression I get transforms IQueryables, for instance this one:
    Expression<Func<IQueryable<int>, double>> input =
        qi => (double)qi.Sum() / qi.Count();
    // I want an expression that transforms IEnumerables:
    Expression<Func<IEnumerable<int>, double>> desiredOutput =
        ei => (double)ei.Sum() / ei.Count();
                
    var cleanSolution = MakeClean(input);
    Expression<Func<IEnumerable<TIn>, TOut>> MakeClean<TIn, TOut>(
        Expression<Func<IQueryable<TIn>, TOut>> original)
    {
        var rewriter = new EnumerableRewriter();
        var newBody = rewriter.Visit(original.Body);
        var replacements = rewriter.GetParameterReplacements();
        var newParams = original.Parameters.Select(p => replacements.TryGetValue(p, out var replacement) ? replacement : p);
        return Expression.Lambda<Func<IEnumerable<TIn>, TOut>>(newBody, newParams);
    }
                
    var compiledDesired = desiredOutput.Compile();
    var compiledClean = cleanSolution.Compile();
    var exampleEnumerable = Enumerable.Range(1, 10);
    var repetitions = 10_000;
    // Desired test:
    var desiredSw = Stopwatch.StartNew();
    for (var i = 0; i < repetitions; ++i)
    {
        var exampleOutput = compiledDesired.Invoke(exampleEnumerable);
    }
    desiredSw.Stop();
    // Clean test:
    var cleanSw = Stopwatch.StartNew();
    for (var i = 0; i < repetitions; ++i)
    {
        var exampleOutput = compiledClean.Invoke(exampleEnumerable);
    }
    cleanSw.Stop();
    Console.WriteLine($"Executed in {cleanSw.ElapsedMilliseconds} ms instead of {desiredSw.ElapsedMilliseconds} ms.");
    // It now executes at roughly the same speed.
