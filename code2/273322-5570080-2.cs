    class Data<T> : Data
    {
        
        // Set the type on the parent class
        public Data() : base(typeof(T))
        {
        }
    
        // You can convert this to a collection, etc. as needed
        public T Items { get; set; }
    
        public static Data<T> CreateData<T>()
        {
            return new Data<T>();
        }
    }
