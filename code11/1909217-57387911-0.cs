    List<ICommand> resultCommands = new List<ICommand> {
     	new ThreadSelectCommand(),
    	new ThreadSelectCommand(),
    	new ThreadSelectCommand(),
    	new SearchCommand(),
    	new SearchCommand(),
    };	
    
    
    var groups = resultCommands.GroupBy(x => x.GetType());
    
    var distinctList = groups.Select(g => { 
    	if(g.Key == typeof(ThreadSelectCommand))
    	{
    		return g.Select(x => (ThreadSelectCommand)x).GroupBy(x => new { x.Value }).Select(x => (ICommand)x.First()).First();
    	}
    	else if(g.Key == typeof(SearchCommand))
    	{
    		return g.Select(x => (SearchCommand)x).GroupBy(x => new { x.Value }).Select(x => (ICommand)x.First()).First();
    	}
    	else 
    	{
    		throw new NotSupportedException();
    	}
    	
    	}).ToList();
