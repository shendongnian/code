    public class Node<T> {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public override string ToString() {
            return Data.ToString();
        }
        public Node(T data) {
            Data = data;
        }
        public Node<T> AppendNode(T data) {
            var newNode = new Node<T>(data);
            var current = this;
            while (current.Next != null)
                current = current.Next;
            current.Next = newNode;
            return newNode;
        }
        /// <summary>
        /// Inserts a new node into the linkedlist as the desired position
        /// </summary>
        /// <param name="position">0-based index for the final position of new node</param>
        /// <param name="newNode">The newly created node containing data</param>
        /// <returns>returns the first node of the linkedlist</returns>
        public Node<T> InsertNode(T data, int position, out Node<T> newNode) {
            var current = this;
            position--;
            newNode = new Node<T>(data);
            if (position < 0) {
                newNode.Next = current;
                return newNode;
            }
            for (int i = 0; i < position; ++i)
                current = current.Next;
            newNode.Next = current.Next;
            current.Next = newNode;
            return this;
        }
    }
    class Program {
        static void Main(string[] args) {
            var linkedList = new Node<int>(10);
            linkedList.AppendNode(11);
            linkedList.AppendNode(12);
            linkedList.AppendNode(13);
            linkedList.AppendNode(14);
            linkedList.AppendNode(15);
            linkedList = linkedList.InsertNode(20, 0, out var newNode);
        }
    }
