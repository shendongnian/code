    HashSet<Game> gamesOfTheDay = new HashSet<Game>();
    while(gamesOfTheDay.Count < limit && gamesOfTheDay.Count < games.Length)
    {
        int idx = rng.Next(games.Length);
        gamesOfTheDay.Add(games[idx]);
    }
