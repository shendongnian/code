    public class Tree<T> : ITree<T> where T : INode{
        public T RootNode { get; private set; }
        public Tree(T rootNode){
            RootNode = rootNode;
        }
    }
    
    public interface ITree<T> where T : INode{
        T RootNode { get; }
    }
    
    public interface INode{
        INode Parent { get; }
        List<INode> Children { get; }
    }
    
    internal class Node : INode{
        public INode Parent { get; private set; }
        public List<INode> Children { get; private set; }
        public Node( INode parent, List<INode> children = new List<INode>()){
            Parent = parent;
            Children = children;
        }
    }
