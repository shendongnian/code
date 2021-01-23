    public class Container<TNode, T> where TNode : Node<T> { }
    public abstract class Node<T>
    {
        Container<Node<T>, T> container;
        public Node(Container<Node<T>, T> owner)
        {
            this.container = owner;
        }
    }
    public class ContainerNormal<T> : Container<Node<T>, T> { }
    public class NodeNormal<T> : Node<T>
    {
        public NodeNormal(ContainerNormal<T> container)
            : base(container)
        {
        }
    }
    public class ContainerNormal : ContainerNormal<string> { }
    public class NodeNormal : NodeNormal<string>
    {
        public NodeNormal(ContainerNormal container)
            : base(container)
        {
        }
    }
