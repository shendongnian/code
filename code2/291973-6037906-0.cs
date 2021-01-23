    public class ObjectFactory
    {
        private readonly Dictionary<MyObjectType, Func<MyObject>> _store = new Dictionary<MyObjectType, Func<MyObject>>();
        public void Register<T>(MyObjectType type) where T: MyObject, new()
        {            
            this.Register(type, () => new T());
        }
        public void Register(MyObjectType type, Func<MyObject> factory)
        {
            _store.Add(type, factory);
        }
        public MyObject CreateInstance(MyObjectType type)
        {
            Func<MyObject> factory;
            if(_store.TryGetValue(type, out factory))
            {
                return factory.Invoke();
            }
            return null;
        }
    }
    public enum MyObjectType { A, B }
    public class MyObject {}
    public class MyObjectA : MyObject {}
    public class MyObjectB : MyObject {}
