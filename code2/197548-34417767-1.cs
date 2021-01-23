    class NonGenericWrapper<T> : IAdaptor
    {
        private readonly Adaptee<T> _adaptee;
     
        public NonGenericWrapper(Adaptee<T> adaptee)
        {
            _adaptee = adaptee;
        }
     
        public object Value
        {
            get { return _adaptee.Value; }
            set { _adaptee.Value = (T) value; }
        }
    }
