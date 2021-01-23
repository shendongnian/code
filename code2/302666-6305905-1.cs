    class MyWrapper
    {
        private Dictionary<string, object> properties = 
                                             new Dictionary<string, object>();
    
        public MyWrapper Clone()
        {
            MyWrapper output = new MyWrapper();
    
            output.properties = new Dictionary<string, object>(properties);
        }
    }
