    namespace ConsoleApp1
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
    
            // constructor
            public Node(int data)
                : this(null, data)
            { }
            // always add a full constructor
            public Node(Node next, int data)
            {
                this.Data = data;
                this.Next = next;
            }
        }
    
        public class LinkedList
        {
            public Node Head { get; set; }
    
            public string PrintList()
            {
                // traversing list and printing the contents starting from head(1)
                Node n = Head;
                int count = 0;
                StringBuilder sb = new StringBuilder();
                while (n != null)
                {
                    count++;
                    sb.Append("Node" + count + ":" + " " + n.Data + " ");
                    n = n.Next;
                }
                return sb.ToString();
            }
    
            // adds node to list
            public void Push(int data)
            {
    
                //allocate new node, put in data
                //and make next of new node as head
                //moving head to point to the new node
                Head = new Node(Head, data); 
            }
    
            public Node FindPrevious(Node node)
            {
                Node n = Head;
                while (n!=null)
                {
                    if (n.Next == node)
                    {
                        return n;
                    }
                    n = n.Next;
                }
                return null;
            }
    
            public void DeleteNode(Node node)
            {
                if (node==null)
                {
                    return;
                }
                Node prev = FindPrevious(node);
                if (prev!=null)
                {
                    // skip over node
                    prev.Next = node.Next;
                }
            }
        }
        static class Program
        {
            static void Main(string[] args)
            {
                LinkedList llist = new LinkedList();
    
                llist.Push(5);
                llist.Push(4);
                llist.Push(3);
                llist.Push(2);
                llist.Push(1);
                llist.Push(0);
    
                Console.WriteLine($"Print List:");
                Console.WriteLine(llist.PrintList());
                Console.WriteLine();
                var existingNode = llist.Head.Next.Next.Next.Next;
                Console.WriteLine($"Deleting {existingNode.Data}");
                llist.DeleteNode(existingNode);
                Console.WriteLine($"Print List:");
                Console.WriteLine(llist.PrintList());
            }
        }
    }
