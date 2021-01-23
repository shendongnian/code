    void Execute(Expression<Func<ParallelQuery<string>, IEnumerable<bool>>> expression, IEnumerable<string> strings)
    {
        ParallelQuery<string> parStrings;
        if (!typeof (ParallelQuery<string>).IsAssignableFrom(strings.GetType()))
            parStrings = strings as ParallelQuery<string>;
        else
            parStrings = strings.AsParallel();
    
        expression.Compile()(parStrings);
    }
