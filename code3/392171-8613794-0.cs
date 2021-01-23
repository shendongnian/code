    public abstract class MyParentClass
    {
        public enum MyEnum
        {
            one,
            two,
            three
        }
    
        private MyEnum _enumeration;
    
        public string Name { get; private set; }
        public MyEnum Enumeration { get { return this._enumeration; } }
        public void SetEnumeration(string value)
        {
            // ... do something
        }
        public void SetEnumeration(MyEnum value)
        {
            // ... do something
        }
    }
