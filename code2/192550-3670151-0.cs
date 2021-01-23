    public class MyDerivedClass : INode
    {
        public ClassDerivedOptions Options { get; set; }
        public ClassOptions INode.Options { get { return Options; } }
    }
