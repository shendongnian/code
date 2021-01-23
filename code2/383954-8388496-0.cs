    class Class1
    {
        // Fields
        private string _property1;       //Required for usage
        private List<object> _property2 = new List<object>(); //Not required for usage
    
        // Properties
        public string Property1 
        { 
            get
            {
                return this._property1;
            }            
            set
            {
                Contract.Requires(value != null);
                this._property1 = value;
            } 
        }
        public List<object> Property2 
        { 
            get
            {
                return this._property2;
            }
            //We don't have a setter.
        }
    
        public Class1(string property1)
        {
            Contract.Requires(property1 != null);
    
            this.Property1 = property1;
        }
    }
