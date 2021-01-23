    public T Example<T, TResult>(Func<T, TResult> f)
        where T : class
        where TResult : class
    {
        Contract.Requires(f != null);
        f = WrapWithContracts(f);
        // ...
    }
    private Func<T, TResult> WrapWithContracts<T, TResult>(Func<T, TResult> f)
        where T : class
        where TResult : class
    {
        return p =>
        {
            Contract.Requires(p != null);
            Contract.Ensures(Contract.Result<TResult>() != null);
            var result = f(p);
            return result;
        };
    }
