    interface ISomeConstructor
    {
        void Save();
    }
    class SomeConstructor
    {
        ISomeConstructor impl;
        public SomeConstructor(string name, object someObject)
        {
            impl = new StringAndObject(name, someObject);
        }
        public SomeConstructor(string name)
        {
            impl = new JustString(name);
        }
        public void Save()
        {
            impl.Save();
        }
    }
