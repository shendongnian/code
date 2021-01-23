    public class ManagerDictionary{
        private Dictionary<Type, object> _managers = new Dictionary<Type, object>();
        public Manager<T> GetManager<T>()
        {
            if (_managers.ContainsKey(typeof(T)))
            {
                return _managers[typeof(T)] as Manager<T>;
            }
            throw new ArgumentException("No manager of " + typeof(T).Name + " could be found");
        }
        public void AddManager<T>(Manager<T> manager)
        {
            _managers.Add(typeof(T),manager);
        }
    }
