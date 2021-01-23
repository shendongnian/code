    public class Node<T>
    {
        private readonly T data;
        private Node<T> next;
        public Node(T data)
        {
            this.data = data;
        }
        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
        public T Data
        {
            get
            {
                return this.data;
            }
        }
        public Node<T> Next
        {
            get
            {
                return this.next;
            }
            set
            {
                this.next = value;
            }
        }
    }
