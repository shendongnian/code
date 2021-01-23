    class Data<T> 
    {
        
        // Your property; can change to collection, etc.
        public T Items { get; set; }
    
    
        // A Lookup dictionary for processing methods
        private static readonly IDictionary<Type, Func<Data<T>, T>> _processFunctions = new Dictionary
            <Type, Func<Data<T>, T>>()
             {
                 {typeof(int), data => { return DoSomethingForInt(data); }},
                 {typeof(string), data => { return DoSomethingForString(data); }},
                 {typeof(double), data => { return DoSomethingForDouble(data); }},
                
             };
    
        public static Data<T> CreateData<T>()
        {
            return new Data<T>();
        }
    
    
        public static T Process(Data<T> data)
        {
            return _processFunctions[typeof(T)](data);
        }
    
    }
