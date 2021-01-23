        public void returnData()
        {
            if (tailNode.next != null)
            {
                Node currentNode = tailNode;
                while (currentNode != null)
                { 
                    Console.WriteLine(currentNode.data + "\n");
                    currentNode = currentNode.next;
                }
            }
            else
                Console.WriteLine("Not Available");
        }
