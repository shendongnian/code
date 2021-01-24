    public static void Main()
    	{
    		
    		
    		BST bst = new BST();
    		
    		
	   	    bst.Insert(5);
		    bst.Insert(6);
		    bst.Insert(4);
		    bst.Insert(7);
		    bst.Insert(3);
    		
    		Console.WriteLine(bst.Root.Data + " ");
    		Console.WriteLine(bst.Root.Left.Data + " ");
            Console.WriteLine(bst.Root.Right.Data + " ");
    		Console.WriteLine(bst.Root.Left.Left.Data + " ");
    		Console.WriteLine(bst.Root.Right.Right.Data + " ");
    		
    		
    	}
