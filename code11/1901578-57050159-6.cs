    public class Repository
    {
        private Dictionary<Type, object> _store = new Dictionary<Type, object>();
        public void Store(Type id, Func<string[], int> value)
        {
            _store[id] = value;
        }
        // optional
        public void Store<T>(Func<string[], int> value) => this.Store(typeof(T), value);
        public Func<string[], int> Fetch(Type id)
        {
            return (Func<string[], int>)_store[id];
        }
        // optional
        public Func<string[], int> Fetch<T>() => this.Fetch(typeof(T));
    }
