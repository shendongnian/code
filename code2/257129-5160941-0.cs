    class Container<T> : IContainer
    {
        public T Value { get; private set; }
        
        public Container(T value)
        {
            Value = value;
        }
        
        public T GetValue()
        {
            return Value; 
        }
        object IContainer.GetValue()
        {
            return this.GetValue();
        }
    }
