    class Node
    {
        public string Id;
        public string ParentID;
        public int Level;
        public Node SetLevel(int i)
        {
            Level = i;
            return this;
        }
    }
    void Main()
    {
        var source = new List<Node>(){
		 new Node(){ Id = "1" },
		 new Node(){ Id = "2", ParentID="1"},
		 new Node(){ Id = "3", ParentID="1"},
		 new Node(){ Id = "4", ParentID="2"}
		 };
        var queue = source.Where(p => p.ParentID == null).Select(s => s.SetLevel(0)).ToList();
        var cur = 0;
        while (queue.Any())
        {
            var n = queue[0];
            queue.AddRange(source.Where(p => p.ParentID == n.Id).Select(s => s.SetLevel(n.Level + 1)));
            queue.RemoveAt(0);
        }
        source.Dump();
    }
