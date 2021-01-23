    public interface INode
    {
        NodeModel CreateModel();
    }
    public abstract class Node<T> : INode where T : NodeModel
    {
        public abstract T CreateModel();
        // Explicit interface implementation so we can implement INode.CreateModel
        // with a different return type. Just delegate to the strongly-typed method.
        NodeModel INode.CreateModel()
        {
            return CreateModle();
        }
    }
