    static void Main(string[] args)
    {
    	var test = CreateTestCompilation();
    	if (test == null)
    	{
    		return;
    	}
    
    	foreach (SyntaxTree sourceTree in test.SyntaxTrees)
    	{
    		Console.WriteLine(souceTree.ToFullString());
    	}
    }
