    public class IndexedClass
    {
        public string SomeProperty { get; set; }
        Hashtable _items = new Hashtable();
        public object this[object key]
        {
            get
            {
                return _items[key];
            }
            set
            {
                _items[key] = value;
            }
        }
        public object this[int key]
        {
            get
            {
                return _items[key];
            }
            set
            {
                _items[key] = value;
            }
        }
    }
