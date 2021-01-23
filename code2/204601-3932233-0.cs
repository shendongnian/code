    class MyClass
    {
        public int MyProperty { get; set; }
    }
    
    class MyProxyClass
    {
        public MyProxyClass(MyClass myClass)
        {
            _myClass = myClass;
        }
    
        private MyClass _myClass;
    
        public int MyProperty
        {
            get { return _myClass.MyProperty; }
        }
    }
