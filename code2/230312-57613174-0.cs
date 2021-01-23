c#
    /// <summary>
    /// Write code to remove duplicates from an unsorted linked list.
    /// </summary>
    class RemoveDups<T>
    {
        private class Node
        {
            public Node Next;
            public T Data;
            public Node(T value)
            {
                this.Data = value;
            }
        }
        private Node head = null;
        public static void MainMethod()
        {
            RemoveDups<int> rd = new RemoveDups<int>();
            rd.AddNode(15);
            rd.AddNode(10);
            rd.AddNode(15);
            rd.AddNode(10);
            rd.AddNode(10);
            rd.AddNode(20);
            rd.AddNode(30);
            rd.AddNode(20);
            rd.AddNode(30);
            rd.AddNode(35);
            rd.PrintNodes();
            rd.RemoveDuplicates();
            Console.WriteLine("Duplicates Removed!");
            rd.PrintNodes();
        }
        private void RemoveDuplicates()
        {
            //use a hashtable to remove duplicates
            HashSet<T> hs = new HashSet<T>();
            Node current = head;
            Node prev = null;
            //loop through the linked list
            while (current != null)
            {
                if (hs.Contains(current.Data))
                {
                    //remove the duplicate record
                    prev.Next = current.Next;
                }
                else
                {
                    //insert element into hashset
                    hs.Add(current.Data);
                    prev = current;
                }
                current = current.Next;
            }
        }
        /// <summary>
        /// Add Node at the beginning
        /// </summary>
        /// <param name="val"></param>
        public void AddNode(T val)
        {
            Node newNode = new Node(val);
            newNode.Data = val;
            newNode.Next = head;
            head = newNode;
        }
        /// <summary>
        /// Print nodes
        /// </summary>
        public void PrintNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
