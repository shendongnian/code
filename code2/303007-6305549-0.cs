    class Pair<A, B>
    {
        public A Key { get; set; }
        public B Value{ get; set; }
    }
    var items = new List<Pair<string, string>>();
    items.Add(new Pair<string,string>() { Key = "", Value = "Test" });
    items.Add(new Pair<string,string>() { Key = "", Value = "Test" });
