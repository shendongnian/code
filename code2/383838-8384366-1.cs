    public void Insert(int value)
    {
        TreeNode current = this;
        while (current != null)
        {
            if(current.Data < value)
                if(current.LeftNode == null)
                { current.LeftNode = new TreeNode(value); break; }
                else current = current.LeftNode;
            else
                if(current.RightNode == null)
                { current.RightNode = new TreeNode(value); break; }
                else current = current.RightNode;
        }
    }
