    public sealed class Node<T>
    {
        public T Item { get; private set; }
        public bool IsRed { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node(T value)
        {
            Item = value;
            IsRed = true;
        }
        public Node(T value, bool isRed)
        {
            Item = value;
            IsRed = isRed;
        }
    }
