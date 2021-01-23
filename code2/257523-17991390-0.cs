    public class SomeClass
    {
        private BaseClass[] _itemArray;
        [XmlElement(typeof(DerivedClass1))]
        [XmlElement(typeof(DerivedClass2))]
        public BaseClass[] ItemArray
        { 
            get { return _itemArray; }
            set { _itemArray = value; }
    }
