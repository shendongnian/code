    class WellknownKeyNotFoundException : KeyNotFoundException
    {
        public WellknownKeyNotFoundException(object key, string message)
            : this( key  , message, null) { }
    
        public WellknownKeyNotFoundException(object key, string message, Exception innerException)
            : base(message, innerException)
        {
            this.Key = key;
        }
    
        public object Key { get; private set; }
    }
