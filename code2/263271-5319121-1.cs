    List<GameItem> sortedList = rows
        .SelectMany(r => r.Games) // flattens to an ienumerable of games
        .Where(g => g.Name == gameName) // filters by the game name
        .OrderBy(g => g.Version) // orders by the game's version
        .ToList(); // converts the ienumerable to a list (of games).
