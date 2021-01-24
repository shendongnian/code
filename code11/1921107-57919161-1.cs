    public interface IQuery<TResult>
    {
        TResult Value { get; set; }
    }
    public interface IQueryHandler<TResult>
    {
        TResult Handle<TQuery>(TQuery query) where TQuery : IQuery<TResult>;
    }
    public class Query : IQuery<bool>
    {
        public bool Value { get; set; }
    }
    
    public class QueryHandler : IQueryHandler<bool>
    {
        public bool Handle<TQuery>(TQuery query) where TQuery : IQuery<bool>
        {
            return query.Value;
        }
    }
    
    public class Dispatcher
    {
        private readonly Dictionary<Type, object> handlers = new Dictionary<Type, object>();
    
        public Dispatcher()
        {
            handlers.Add(typeof(Query), new QueryHandler());
        }
    
        public T Dispatch<T>(IQuery<T> query)
        {
            if (handlers.ContainsKey(query.GetType()))
            {
                var queryHandler = (IQueryHandler<T>)handlers[query.GetType()];
                return queryHandler.Handle(query);
            }
    
            throw new NotSupportedException();
        }
    }
