    public class DataNode
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public List<DataNode> Children { get; private set; }
        public DataNode(int id, string name)
        {
            Id = id;
            Name = name;
            Children = new List<DataNode>();
        }
    }
