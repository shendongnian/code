    public class IndexedClass
    {
        public string SomeProperty { get; set; }
        public int[] SomeTable { get; set; } = new int[] { 3, 4, 5 };
        
        Hashtable _items = new Hashtable();
        public object this[object key]
        {
            get
            {
                Console.WriteLine("object key");
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
                Console.WriteLine("int key");
                return _items[key];
            }
            set
            {
                _items[key] = value;
            }
        }
    }
