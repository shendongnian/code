    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.AddFirst(0);
            linkedList.Print();            
        }
    }
    public class Node
    {
        public Node(Node next, Object value)
        {
            this.next = next;
            this.value = value;
        }
        public Node next;
        public Object value;
    }
    public class LinkedList
    {
        public Node head;
        public LinkedList(Object initial)
        {
            head = new Node(null, initial);
        }
        public void AddFirst(Object value)
        {
            head = new Node(head, value);            
        }
        public void Add(Object value)
        {
            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = new Node(null, value);
        }
        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.value);
                current = current.next;
            }
        }
    }
