    public class SomeClass
    {        
        // ... constructor and other stuff
        private int? calculation = null;
    
        public int SomeProperty
        {
            get
            {
                if (!calculation.HasValue)
                    calculation = SomeHeayCalculation();
                return calculation.Value;
            }
        } 
    }
