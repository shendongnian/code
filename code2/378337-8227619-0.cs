    public static class First
    {
        private Static MyObject _myproperty;
        static First() {}
        public static MyProperty
        {
            get 
            { 
                 if(_myproperty == null) _myproperty = new MyObject();
                 return _myproperty; 
            }
            set { _myproperty = value; }
        }
    }
    
    public static class Second
    {
        static Second() {}
        public static MyProperty
        {
            get { return First.MyProperty; }
            set { First.MyProperty= value; }
        }
    }
