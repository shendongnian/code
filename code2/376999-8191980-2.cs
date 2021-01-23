        List<tblArcadeGame> q;
        /* object q; */
        
        if (CategoryID == 0)
        {
            q = db.tblArcadeGames.OrderByDescending(c => c.Plays).Take(Fetch).ToList();
        }
        else
        {
            q = db.tblArcadeGames.Where(c=>c.CategoryID == CategoryID).OrderByDescending(c => c.Plays).Take(Fetch).ToList();
        }
            r = new Game[q.Count()];
            int i = 0;
            foreach (var g in q)
            {
                r[i] = new Game(g);
                i++;
            }
