    interface IRepository<T>
    {
        T GetData();
    }
    class Container
    {
        private object[] data = null;
        
        public T Resolve<T>()
        {
            return(T)data.First(t => t.GetType() is T);
        }
    }
    abstract class Handler<T>
    {
        private Container _container;
        public IRepository<T> Table
        {
            get
            {
                return _container.Resolve<IRepository<T>>();
            }
        }
    }
