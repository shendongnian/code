    interface INode
    {
        List<INode> Children { get; }
        void AddRange(IEnumerable<INode> children);
    }
    class Node : INode
    {
        List<INode> Children { get; private set; }
        void AddRange(IEnumerable<INode> children)
        {
            Children.AddRange(children);
        }
    }
