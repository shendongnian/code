    class Class1
    {
        public Class2 property1
        {
            get
            {
                return new Class2();
            }
        }
    }
    
    class Class2
    {
        public some_type property2
        {
            get
            {
                return some_value;
            }
        }
    }
