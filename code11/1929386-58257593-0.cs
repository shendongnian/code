    class MessageBus
    {
        private readonly Dictionary<Type, Lazy<Action<object>>> _handlers = new Dictionary<Type, Lazy<Action<object>>>();
        public void AddHandler<T>(Func<IMessageHandler<T>> handlerFactory)
        {
            Func<Action<object>> objectHandlerFactory = CreateObjectHandlerFactory(handlerFactory);
            _handlers[typeof(T)] = new Lazy<Action<object>>(objectHandlerFactory);
        }
        public void Handle(object message)
        {
            _handlers[message.GetType()].Value(message);
        }
        private Func<Action<object>> CreateObjectHandlerFactory<T>(Func<IMessageHandler<T>> handlerFactory)
        {
            return () =>
            {
                var handler = handlerFactory();
                return message => handler.Handle((T)message);
            };
        }
    }
