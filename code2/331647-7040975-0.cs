    class SomeClass {
        Dictionary<string,object> d;
        // add ISerializable
        public void Add(string key, ISerializable value) {
            d[key] = value;
        }
        // add primitive types
        public void Add(string key, bool value) {
            d[key] = value;
        }
        public void Add(string key, int value) {
            d[key] = value;
        }
        // etc ...
    }
