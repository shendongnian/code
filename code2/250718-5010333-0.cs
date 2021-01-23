    public class IsDirtyDecorator<T>
    {
        private T _myValue;
        private Action<bool> _changedAction;
        
        public IsDirtyDecorator<T>(Action<bool> changedAction = null)
        {
            _changedAction = changedAction;
        }
        
        public bool IsDirty { get; private set; }
    
        public T Value
        {
            get { return _myValue; }
            set
            {
                _myValue = value;
                IsDirty = true;
                if(_changedAction != null)
                    _changedAction(IsDirty);
            }
        }
    }
