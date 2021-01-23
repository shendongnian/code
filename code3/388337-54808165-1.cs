    public Task<TResult> ProcessAsync<TQuery, TResult>(IQuery<TQuery, TResult> query)
        where TQuery: IQuery<TQuery, TResult>
    {
        var handler = serviceProvider.Resolve<QueryHandler<TQuery, TResult>>();
        // etc.
    }
