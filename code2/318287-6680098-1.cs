    var rand = new Random();
    var randomGames = new List<game>();
    while(randomGames.Count < limit)
    {
       var aGame = games.AllActive[rand.Next(limit)];
       if (!randomGames.Contains(aGame))
       {
          randomGames.Add(aGame);
       }
    }
