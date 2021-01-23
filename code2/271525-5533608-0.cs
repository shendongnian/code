    public interface INodeBase
    {
    }
    public interface INodeContainer : INodeBase
    {
    }
    public interface INodeContainer<C> : INodeContainer
        where C : INodeBase
    {
        IList<C> Children { get; }
    }
    public interface INodeFolder : INodeContainer<INodeContainer>
    {
    }
    public interface INodeItem : INodeContainer<INodeResult>
    {
    }
    public interface INodeResult : INodeBase
    {
    }
