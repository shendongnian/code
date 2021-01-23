    public abstract class Data
    {
    
        // A Lookup dictionary for processing methods
        // Note this the functions just return something of type object; specialize as needed
        private static readonly IDictionary<Type, Func<object, Data>> _processFunctions = new Dictionary
            <Type, Func<object, Data>>()
             {
                 {typeof(int), d => { return doSomethingForInt( (Data<int>) d); }},
                 {typeof(string), d => { return doSomethingForString( (Data<string>) d); }},
                 {typeof(double), d => { return doSomethingForDouble( (Data<double>) d); }},
                
             };
    
        // A field indicating the subtype; this will be used for lo
        private readonly Type TypeOfThis;
    
        protected Data(Type genericType)
        {
            TypeOfThis = genericType;
        }
    
        public Data Process()
        {
            return _processFunctions[this.TypeOfThis](this);
        }
    
    }
