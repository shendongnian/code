    private class NodeInfo
    {
      public NodeInfo(TreeNode node, int len)
      {
        Node = node;
        Len = len;
      }
      
      public TreeNode Node {get; private set;}
      public int Len {get; private set;}
    }
    
    public void HeightIterative()
    {
    	int maxLen = 0;
    
    	var queue = new Queue<NodeInfo>();
    	queue.Enqueue(new NodeInfo(root, 1));
    
    	while (queue.Count > 0)
    	{
    		var item = queue.Dequeue();
    		var current = item.Node;
    		var currentLen = item.Len;
    
    		if (current.LeftNode != null)
    		{
    			queue.Enqueue(new NodeInfo(current.LeftNode, currentLen + 1));
    		}
    
    		if (current.RightNode != null)
    		{
    			queue.Enqueue(new NodeInfo(current.RightNode, currentLen + 1));
    		}
    
    		if (currentLen > maxLen)
    		{
    			maxLen = currentLen;
    		}
    	}
    
    	Console.WriteLine("The Height Of Tree Is: " + maxLen);
    }
