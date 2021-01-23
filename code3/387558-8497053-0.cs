    public class MyRecord
    {
        public int Id {get; set; }
        public int ParentId {get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        // The children of this node
        public MyRecordCollection Children = new MyRecordCollection();
    }
