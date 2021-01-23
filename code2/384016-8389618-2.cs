    public void HeightIterative()
    {
    	int maxLen = 0;
    
    	var queue = new Queue<Tuple<TreeNode, int>>();
    	queue.Enqueue(Tuple.New(root, 1));
    
    	while (queue.Count > 0)
    	{
    		var item = queue.Dequeue();
    		var current = item.ItemA;
    		var currentLen = item.ItemB;
    
    		if (current.LeftNode != null)
    		{
    			queue.Enqueue(Tuple.New(current.LeftNode, currentLen + 1));
    		}
    
    		if (current.RightNode != null)
    		{
    			queue.Enqueue(Tuple.New(current.RightNode, currentLen + 1));
    		}
    
    		if (currentLen > maxLen)
    		{
    			maxLen = currentLen;
    		}
    	}
    
    	Console.WriteLine("The Height Of Tree Is: " + maxLen);
    }
