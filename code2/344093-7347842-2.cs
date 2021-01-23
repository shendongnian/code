        public void returnData()
        {
            if (headNode.next != null)
            {
                Node currentNode = headNode;
                while (currentNode != null)
                { 
                    Console.WriteLine(currentNode.data + "\n");
                    currentNode = currentNode.next;
                }
            }
            else
                Console.WriteLine("Not Available");
        }
