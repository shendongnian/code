    	var Tests = new List<Test>
    	{
    		new Test
    		{
    			Condition = num => (num >> 5) != 0,
    			Operation = num => { // Do stuff}
    		},
    		new Test
    		{
    			Condition = num => (num & 0x0E) != 0,
    			Operation = num => { // Do other stuff}
    		}
            // Add all your 80+ tests here
    	};
    
    // Then use a single if:
    foreach (var test in Tests)
    {
    	if(test.Condition(Number))
    	{
    		test.Operation(Number);
    		return false;
    	}
    }
    
    
