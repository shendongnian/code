    public abstract class GenericNode<Node, Container>
        where Node : GenericNode<Node, Container>
        where Container : GenericNode<Node, Container>.GenericContainer<Node>
    {
        Container parent;
        Node nextNode;
        Node previousNode;
        public abstract class GenericContainer<Branch> where Branch: GenericNode<Node, Container> 
        {
            private Leaf firstChild;
            private Leaf secondChild;
        }
    }
