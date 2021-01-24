      public void Insert(int data)
        {
            if (root == null)
            {
                root = new Node(data);
    
            }
            else
            {
                root = InsertHelper(root, data);
    
            }
        }
