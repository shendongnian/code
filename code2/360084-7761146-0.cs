    public class BTreeNode<T> where T : BTreeNode<T>
    {
        public T Left { get; set; }
        public T Right { get; set; }
    }
