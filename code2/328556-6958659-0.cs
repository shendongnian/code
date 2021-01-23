    public class LinkedList<T>
    {
        private Node<T> head;
        public void AddAtFront(T data)
        {
            this.head = new Node<T>(data, this.head);
        }
        public void AddAtBack(T data)
        {
            var node = new Node<T>(data);
            var current = this.head;
            if (current == null)
            {
                this.head = node;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }
        }
        public Node<T> Front
        {
            get
            {
                return this.head;
            }
        }
        public Node<T> Back
        {
            get
            {
                var current = this.head;
                if (current != null)
                {
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }
                }
                return current;
            }
        }
        public Node<T> RemoveAtFront()
        {
            var node = this.head;
            if (node != null)
            {
                this.head = node.Next;
            }
            return node;
        }
        public Node<T> RemoveAtBack()
        {
            var current = this.head;
            if (current != null)
            {
                if (current.Next == null)
                {
                    this.head = null;
                }
                else
                {
                    Node<T> nextToLast = null;
                    while (current.Next != null)
                    {
                        nextToLast = current;
                        current = current.Next;
                    }
                    nextToLast.Next = null;
                }
            }
            return current;
        }
    }
