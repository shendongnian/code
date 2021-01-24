    public Node InsertHelper( Node root, int data)
        {
            if (root == null)
            
                return new Node(data);
               
            
    
            if (root.Data > data)
            {
                 root.Left = InsertHelper(root.Left, data);
            }
    
            if (root.Data < data)
            {
                 root.Right = InsertHelper(root.Right, data);
            }
    
        }
