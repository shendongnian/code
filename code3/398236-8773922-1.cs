    class MessageSystem
    {
        readonly Dictionary<Type, Action<IMessage>> handlers = new Dictionary<Type, Action<IMessage>>();
    
        public void Register<T>(Action<T> action) where T : IMessage
        {
            Action<IMessage> wrapped = (IMessage msg) => action((T)msg);
            handlers[typeof(T)] = wrapped;
        }
        
        public void Invoke(IMessage msg)
        {
            handlers[msg.GetType()](msg);
        }
    }
