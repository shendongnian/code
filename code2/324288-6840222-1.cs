        Dictionary<Type, Action<object>> handlers;
        void AddHandler<T>( Handler<T> handler )
        {
            handlers.Add(typeof(T), m => handler.ProcessMessage((T)m));
        }
        void ProcessMessage(object message)
        {
            var handler = handlers[message.GetType()];
            handler(message);
        }
