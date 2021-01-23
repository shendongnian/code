    public sealed class Mediator
    {
        private static Mediator instance = new Mediator();
        private readonly Dictionary<string, List<Action<object>>> callbacks 
          = new Dictionary<string, List<Action<object>>>();
    
        private Mediator() { }
    
        public static Mediator Instance
        {
            get
            {
                return instance;
            }
        }
        
        public void Register(string id, Action<object> action)
        {
            if (!callbacks.ContainsKey(id))
            {
                callbacks[id] = new List<Action<object>>();
            }
    
            callbacks[id].Add(action);
        }
    
        public void Unregister(string id, Action<object> action)
        {
            callbacks[id].Remove(action);
    
            if (callbacks[id].Count == 0)
            {
                callbacks.Remove(id);
            }
        }
    
        public void SendMessage(string id, object message)
        {
            callbacks[id].ForEach(action => action(message));
        }
    }
