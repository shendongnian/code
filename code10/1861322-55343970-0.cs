    public sealed class JsonInvoker<T>
    {
        private readonly Action<T> _action;
    
        public JsonInvoker(Action<T> action)
        {
            _action = action;
        }
    
        public void Invoke(string json)
        {
            var arg = Deserialize(json);
            _action(arg);
        }
        private T Deserialize(string json) => //...
    }
