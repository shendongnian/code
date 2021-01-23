    private static Game[] getMostPlayedGamesDo(int Fetch, int CategoryID)
    {
        var q = db.tblArcadeGames;
        if (CategoryID != 0)
        {
            q = q.Where(c => c.CategoryID == CategoryID);
        }
        q = q.OrderByDescending(c => c.Plays).Take(Fetch);
        return q.Select(g => new Game(g)).ToArray();
    }
