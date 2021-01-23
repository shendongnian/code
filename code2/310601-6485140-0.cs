    abstract class Node<K, V>
    {
        public K[] Keys { get; protected set; }
    }
    class LeafNode<K, V> : Node<K, V>
    {
        public V[] Values { get; protected set; }
    }
    class InnerNode<K, V> : Node<K, V>
    {
        public Node<K, V> Children { get; protected set; }
    }
