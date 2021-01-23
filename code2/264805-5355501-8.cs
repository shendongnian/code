    public void Print()
        {
            Node current = head;
            Console.Write("List: ");
            while (current != null)
            {
                Console.Write("{0} ", current.Data);
                current = current.Next;
            }
            Console.WriteLine("");
        }
