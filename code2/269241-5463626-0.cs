        public void AddAfter(int number)
        {
            if (FirstNode==null)
            {
                AddBefore(number);
            }
            else
            {
                // Finding the last node
                Node currentNode = FirstNode;
                while (currentNode.NextNode != null)
                    currentNode = currentNode.NextNode;
                
                // Constructing a new node
                Node newNode = new Node();
                newNode.Data = number;
                newNode.Next = null;
                
                // Adding the new node to the end
                currentNode.NextNode = newNode;
            }
        } 
