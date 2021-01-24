    var groupedGamesListing = apiResults.SelectMany(g => {
    	var gg = new GroupedGames
    	{
    		// ...
    		GameId = g.CurrentGameId.ToString(),
    		GameControllerId = (g.GameYear == 2018) ? 34729 : 99483,
    		// ...
    	};
    	return gg; 
    }).ToList();
