        public class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
        } 
        public static Node<T> Reverse<T>(Node<T> head)
        {
            Node<T> tail = null;
            while(head!=null)
            {
                var node = new Node<T> { Value = head.Value, Next = tail };
                tail = node;
                head = head.Next;
            }
            return tail;
        }
