    var groupedGamesListing = apiResults.SelectMany(g => new GroupedGames
    	{
    		// ...
    		GameId = g.CurrentGameId.ToString(),
    		GameControllerId = (g.GameYear == 2018) ? 34729 : 99483,
    		// ...
    	}).ToList();
