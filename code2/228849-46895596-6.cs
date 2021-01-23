    class Tree
    {
        private IDictionary<string, dynamic> dict = new Dictionary<string, dynamic>();
        public dynamic this[string key]
        {
            get { return dict.ContainsKey(key) ? dict[key] : dict[key] = new Tree(); }
            set { dict[key] = value; }
        }
    }
    // Test:
    var a = new Tree();
    a["first"]["second"]["third"] = "text";
    Console.WriteLine(a["first"]["second"]["third"]);
