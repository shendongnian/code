    static IQueryable<T> MyQuery<T>(this Session s)
    {
        Contract.Requires(s != null);
        Contract.Ensures(Contract.Result<IQueryable<T>>() !=  null);
        var result = s.Query<T>();
        Contract.Assume(result != null);
        return result;
    }
