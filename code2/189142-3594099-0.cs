    public class SomeType
    {
        public string A { get; set; }
        public string C { get; set; }
    
        private string _b;
        public string B 
        { 
            get { return _b; } 
            set 
            { 
                // Set B to some new value
                _b = value; 
    
                // Assign C
                C = string.Format("B has been set to {0}", value);
            }
        }
    }
