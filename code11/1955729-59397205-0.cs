    private void Function2(string param2 = "A")
    {
    	// no-op
    	Console.WriteLine($"Param2 = {param2}");
    }
    
    private void Function1(string param1)
    {
    	var actionsDictionary = new Dictionary<bool, Action<string>>
    	{
    		{ false, this.Function2 },
    		{ true, (p) => { this.Function2(); } }
    	};
    
    	actionsDictionary[string.IsNullOrWhiteSpace(param1)](param1);
    }
    
    [TestMethod]
    public void TestNow()
    {
    	Console.WriteLine("Begin invoking Function1 with different params");
    	Function1(null);
    	Function1(String.Empty);
    	Function1("        ");
    	Function1("Some Value");
    	Console.WriteLine("End invoking Function1 with different params");
    }
