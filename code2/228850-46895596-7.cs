    class Tree
    {
        private IDictionary<string, object> dict = new Dictionary<string, object>();
        public dynamic this[string key]
        {
            get { return dict.ContainsKey(key) ? dict[key] : dict[key] = new Tree(); }
            set { dict[key] = value; }
        }
    }
    
    // Test:
    var t = new Tree();
    t["first"]["second"]["third"] = "text";
    Console.WriteLine(t["first"]["second"]["third"]);
