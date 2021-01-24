    public ExecutionResult GetExecutionResult(Variant model)
    {
    	return new ExecutionResult
    	{
    		Name = model.VariantName,
    		AggregateResults = CaclulateAggregates(model);
    	};
    }
    private IEnumerable<AggregateStats> CaclulateAggregates(Variant model)
    {
    	for (int counter = 0; counter < model.Subvariants.Count - 1; counter++)
    	{
    		try
    		{
    			var left = model.Subvariants[counter];
    			var right = model.Subvariants[counter + 1];
    
    			using (var t = new AggregateCalculator(model))
    			{
    				if (counter == 0)
    				{
    					t.Start(0);
    					yield return CreateStats(left.Name);
    				}
    					
    				t.Start(1);
    				yield return CreateStats(left.Name);
    			}
    		}
    		catch
    		{
    			yield return CreateStats(left.Name);
    			yield break;
    		}
    	}
    }
    
    private AggregateStats CreateStats(string name)
    {
    	return new AggregateStats
    	{
    		Name = name,
    		//other properties (add parameters)
    	}
    }
