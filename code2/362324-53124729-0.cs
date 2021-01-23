    // Define enum TestType without values
    enum TestType{}
    // Define a dictionary for enum values
    Dictionary<int,string> d = new Dictionary<int,string>();
    void Main()
    {
    	int i = 5;
    	TestType s = (TestType)i;
    	TestType e = (TestType)2;
    	
    	// Definging enum int values with string values
    	d.Add(2,"Aphasia");
    	d.Add(5,"FocusedAphasia");
    	
    	// Results:
    	Console.WriteLine(d[(int)s]); // Result: FocusedAphasia
    	Console.WriteLine(d[(int)e]); // Result: Aphasia
    }
