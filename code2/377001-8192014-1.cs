    IQueryable<tblArcadeGame> q;
    if (CategoryID == 0)
    {
        q = db.tblArcadeGames.OrderByDescending(c => c.Plays).Take(Fetch);
    }
    else
    {
        q = db.tblArcadeGames.Where(c=>c.CategoryID == CategoryID).OrderByDescending(c => c.Plays).Take(Fetch);
    }
    r = new Game[q.Count()];
    int i = 0;
    foreach (var g in q)
    {
        r[i] = new Game(g);
        i++;
    }
