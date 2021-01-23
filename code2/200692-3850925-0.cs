    public abstract class GenericNode<TNode, TContainer>
        where TNode : GenericNode<TNode, TContainer>
        where TContainer : GenericNode<TNode, TContainer>.GenericContainer
    {
        public TContainer Parent { get; set; }
        public TNode Next { get; set; }
        public TNode Previous { get; set; }
        public abstract class GenericContainer : GenericNode<TNode, TContainer>
        {
            public TNode FirstChild { get; set; }
            public TNode LastChild { get; set; }
        }
    }
