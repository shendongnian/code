    public class DispatcherService<T>
    {
    
        private static readonly DispatcherService<T> _dispatcher = new DispatcherService<T>();
        private Action<T> _action;
    
        private DispatcherService() {}
    
        public static DispatcherService<T> Dispatcher
        {
            get {return _dispatcher ;}
        }
    
        public void SetDispatcher(Action<T> action)
        {
            Dispatcher = action;
        }
    
        public void Dispatch(T obj)
        {
            Dispatcher.Invoke(obj);
        }
    }
