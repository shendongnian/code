    public class MyClass
    {
        private Dictionary<string, object> _innerDictionary = new Dictionary<string, object>();
        public object this[string key]
        {
            get { return _innerDictionary[key]; }
            set { _innerDictionary[key] = value; }
        }
    }
    // Usage
    MyClass c = new MyClass();
    c["Something"] = new object();
