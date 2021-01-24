    public class Dispatcher<TQuery, TResult> where TQuery : IQuery<TResult>, new()
    {
        private readonly Dictionary<Type, object> handlers = new Dictionary<Type, object>();
        public Dispatcher()
        {
            handlers.Add(typeof(Query), new QueryHandler());
        }
        public TResult Dispatch()
        {
            TQuery query = new TQuery();
            IQueryHandler<TQuery, TResult> queryHandler;
            if (!this.handlers.TryGetValue(query.GetType(), out object handler) ||
                ((queryHandler = handler as IQueryHandler<TQuery, TResult>) == null))
            {
                throw new Exception();
            }
            return queryHandler.Handle(query);
        }
    }
