    class YourClass {
        List<string> list = new List<string>();
        public IEnumerable<string> List {
            get { return list; }
        }
        public void Add(string str) {
            list.Add(str);
        }
    }
