    public abstract class NodeBase : INodeBase
    {
    }
    public abstract class NodeBase : INodeBase
    {
    }
    public abstract class NodeContainer : NodeBase, INodeContainer
    {
    }
    public abstract class NodeContainer<C> : NodeContainer, INodeContainer<C>
        where C : INodeBase
    {
        public NodeContainer() { this.Children = new List<C>(); }
        public IList<C> Children { get; private set; }
    }
    public class NodeFolder : NodeContainer<INodeContainer>, INodeFolder
    {
    }
    public class NodeItem : NodeContainer<INodeResult>, INodeItem
    {
    }
    public class NodeResult : INodeResult
    {
    }
