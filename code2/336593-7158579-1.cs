    public class Subtree<T, Node> : DynamicObject, BinaryTreeWithRoot<Node> where T : BinaryTree<Node>
    {
        private readonly T tree;
        public Subtree(T tree)
        {
            this.tree = tree;
        }
    }
