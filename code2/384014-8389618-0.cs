    private int GetLen(TreeNode node)
    {
      var result = 0;
    
      if(node != null)
      {
        result = Math.Max(GetLen(node.LeftNode), GetLen(node.RightNode)) + 1;
      }
    
      return result;
    }
    
    public void HeightIterative()
    {
      int res = GetLen(root);
      Console.WriteLine("The Height Of Tree Is: "+res);
    }
