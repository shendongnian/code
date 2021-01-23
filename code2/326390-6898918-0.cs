    public class SomeClass
    {
        // ... constructor and other stuff
       private bool _propertyCalculated;
       private int _someProperty;
    
        public int SomeProperty
        {
            get
            {
                if (!_propertyCaculated)
                {
                    _someProperty = SomeHeayCalculation();
                    _propertyCaculated = true;
                }
                return _someProperty;
            }
        } 
    }
