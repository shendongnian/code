    public MyClass
    {
        private Foo _myProperty;
        public Foo MyProperty
        {
            get { return _myProperty; }
            set { MyPropertySetter(value); }
        }
    
        public void MyPropertySetter(Foo foo)
        {
            _myProperty = foo;
        }
    }
