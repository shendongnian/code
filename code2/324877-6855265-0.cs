    public sealed class EventAggregator
        {
            #region Fields
    
            private readonly Dictionary<Type, List<Object>> subscribers = new Dictionary<Type, List<Object>>();
    
            #endregion
    
            #region Public Methods
    
            public void Subscribe<TMessage>(Action<TMessage> handler)
            {
                if (subscribers.ContainsKey(typeof(TMessage)))
                {
                    var handlers = subscribers[typeof(TMessage)];
                    handlers.Add(handler);
                }
                else
                {
                    var handlers = new List<Object> {handler};
                    subscribers[typeof(TMessage)] = handlers;
                }
            }
    
            public void Unsubscribe<TMessage>(Action<TMessage> handler)
            {
                if (subscribers.ContainsKey(typeof(TMessage)))
                {
                    var handlers = subscribers[typeof(TMessage)];
                    handlers.Remove(handler);
    
                    if (handlers.Count == 0)
                    {
                        subscribers.Remove(typeof(TMessage));
                    }
                }
            }
    
            public void Publish<TMessage>(TMessage message)
            {
                if (subscribers.ContainsKey(typeof(TMessage)))
                {
                    var handlers = subscribers[typeof(TMessage)];
                    foreach (Action<TMessage> handler in handlers)
                    {
                        handler.Invoke(message);
                    }
                }
            }
    
            #endregion
        }
