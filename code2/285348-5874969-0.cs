    class MyBaseClass
    {
        protected string MyRestrictedProperty { get; set; }
    }
    class MyClass : MyBaseClass
    {
        public string MyPublicProperty 
        {
            get { return MyRestrictedProperty;  }
            set { MyRestrictedProperty = value; }
        }
    }
