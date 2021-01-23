    interface IGenericManager
    {
        Type ManagerType { get; }
    }
    
    GenericManager<T> : IGenericManager
    {
        public Type ManagerType { get { return typeof(T) ; } }
    }
