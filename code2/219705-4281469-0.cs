    private readonly Dictionary<Type,object> mServices = new Dictionary<Type,object>();
    public void Add(Type type,object value)  { ...}
    public object GetService(Type serviceType) { ... }
    public void Remove(Type type)  { ... }
    public T Resolve<T>()  { return (T)this.GetService(typeof(T)); } 
