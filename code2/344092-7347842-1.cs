        public void add(object entry)
        {
            if (headNode == null)
            {
                Node newNode = new Node(entry);
                headNode = newNode;
                ++Node_count;
            }
            else
            {
                if (Node_count == 1)
                {
                    Node newNode = new Node(entry);
                    headNode.next = newNode;
                    tailNode = newNode;                
                }
                else 
                {
                    Node newNode = new Node(entry);
                    tailNode.next = newNode;
                    tailNode = newNode;
                }
                ++Node_count;
            }
        }
