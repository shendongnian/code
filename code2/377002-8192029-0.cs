    var q = CategoryID == 0 ? db.tblArcadeGames.OrderByDescending(c => c.Plays).Take(Fetch)
                            : db.tblArcadeGames.Where(c=>c.CategoryID == CategoryID).OrderByDescending(c => c.Plays).Take(Fetch);
    
    r = new Game[q.Count()];
    int i = 0;
    foreach (var g in q)
    {
        r[i] = new Game(g);
        i++;
    }
