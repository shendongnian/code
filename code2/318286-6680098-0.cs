    var randomGames = new List<game>();
    while(randomGames.Count < limit)
    {
       var aGame = games.AllActive[(int)(DateTime.Today.GetHashCode()) % games.AllActive.Count()];
       if (!randomGames.Contains(aGame))
       {
          randomGames.Add(aGame);
       }
    }
