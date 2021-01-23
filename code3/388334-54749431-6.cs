    static class QueryProcessorExtension
    {
        public static TResult Process<TQuery, TResult>(
            this IQueryProcessor processor, TQuery query,
            //Additional parameter for TQuery -> IQuery<TResult> type resolution:
            Func<TQuery, IQuery<TResult>> typeResolver)
            where TQuery : IQuery<TResult>
        {
            return processor.Process<TQuery, TResult>(query);
        }
    }
