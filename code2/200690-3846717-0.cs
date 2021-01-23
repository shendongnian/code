    public interface ITagged<T>
    {
        T Tag { get; set; }
    }
    public sealed class Tree<T>
    {
        //All Tree operations are performed here (add nodes, remove nodes, possibly move nodes, etc.)
        //Nodes are only exposed as 'ITagged<T>', such as:
        public ITagged<T> Root { get; private set; }
        public IEnumerable<ITagged<T>> GetChildren(ITagged<T> item)
        {
            //Cast to Container and enumerate...
        }
        //Several other tree operations...
        private class Node : ITagged<T>
        {
            Container parent;
            Node nextNode;
            Node previousNode;
            public T Tag { get; set; }
        }
        private class Container : Node
        {
            Node firstChild;
            Node lastChild;
        }
    }
