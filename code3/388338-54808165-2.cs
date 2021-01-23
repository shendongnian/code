    public interface IQueryProcessor
    {
        Task<TResult> ProcessAsync<TQuery, TResult>(IQuery<TQuery, TResult> query)
            where TQuery: IQuery<TQuery, TResult>;
    }
