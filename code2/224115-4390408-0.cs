    void Main()
    {
    	var numbers = Enumerable.Range(1, 5);
    	IEnumerator num = numbers.GetEnumerator();
    	
    	num.MoveNext();
    	ProcessFirstItem(num.Current); // First item
    
    	while(num.MoveNext()) // Iterate rest
    	{
    		Console.WriteLine(num.Current);
    	}
    }
    
    	void ProcessFirstItem(object first)
    	{
    		Console.WriteLine("First is: " + first);
    	}
