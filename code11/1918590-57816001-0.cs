    public class MyNode
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public List<MyNode> Nodes { get; set; }
        
        public MyNode()
        {
            Nodes = new List<MyNode>();
        }
    }
	
