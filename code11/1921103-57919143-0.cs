    public class Dispatcher<TResult> 
    {
        private readonly Dictionary<Type, object> handlers = new Dictionary<Type, object>();
        public Dispatcher()
        {
            handlers.Add(typeof(Query), new QueryHandler());
        }
        public TResult Dispatch<TQuery>(TQuery query) where TQuery : IQuery<TResult>
        {
            IQueryHandler<TQuery, TResult> queryHandler;
            if (!this.handlers.TryGetValue(query.GetType(), out object handler) ||
                ((queryHandler = handler as IQueryHandler<TQuery, TResult>) == null))
            {
                throw new Exception();
            }
            return queryHandler.Handle(query);
        }
    }
