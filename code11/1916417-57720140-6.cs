    public static void Main()
    	{
    		
    		
    		BST bst = new BST();
    		
    		bst.Root = bst.InsertHelper(bst.Root, 5);
    		bst.Root = bst.InsertHelper(bst.Root, 6);
    		bst.Root = bst.InsertHelper(bst.Root, 4);
    		bst.Root = bst.InsertHelper(bst.Root, 7);
    		bst.Root = bst.InsertHelper(bst.Root, 3);
    		
    		Console.WriteLine(bst.Root.Data + " ");
    		Console.WriteLine(bst.Root.Left.Data + " ");
            Console.WriteLine(bst.Root.Right.Data + " ");
    		Console.WriteLine(bst.Root.Left.Left.Data + " ");
    		Console.WriteLine(bst.Root.Right.Right.Data + " ");
    		
    		
    	}
