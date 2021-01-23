    public class ShortName<T>
    {
        public string ValueString 
        { 
            get 
            {
                return Value.ToString(); // be aware of null ref here!
            }
        }
        private Type ValueType 
        { 
            get 
            {
                return typeof(T);
            }
        }
    
        public T Value
        {
            get; set;
        }
    }
