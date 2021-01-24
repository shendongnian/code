    public class ExampleClass
    {
        //Static Functionality
        private static ExampleClass _inst;
        public static ExampleClass Instance
        {
            get
            {
                if (_inst is null)
                {
                    _inst = new ExampleClass();
                    _inst.Init();
                }
                return _inst;
            }
    
        }
    
    
        //Class Values
        public static int MyValue;
    
        public int Value1;
    
        //private Constructor 
        private ExampleClass()
        {
    
        }
    
    
        //initialize values here
        private void Init()
        {
            
        }
    
    }
