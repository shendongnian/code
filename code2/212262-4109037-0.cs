    [AttributeUsage(AttributeTargets.Method)]
    class MyMethodAttribute : Attribute { }
    class MyClass
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            [MyMethodAttribute] // this works because "Method" is a valid target for this attribute
            [Obsolete] // this does not work, even though "Method" is a valid target for the Obsolete attribute
            set { _Id = value; }
        }
    }
