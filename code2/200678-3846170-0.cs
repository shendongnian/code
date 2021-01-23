    public abstract class GenericNode<Node, Container>
        where Node : GenericNode<Node, Container>
        where Container : GenericNode<Node, Container>.GenericContainer
    {
        Container parent;
        Node nextNode;
        Node previousNode;
        public abstract class GenericContainer: GenericNode<Node, Container>
        {
            Node firstChild;
            Node lastChild;
        }
    }
