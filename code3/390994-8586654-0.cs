    var q = from c in db.tblArcadeGamePlays
            where c.GameID == GameID && c.ReferalID != 0 && c.ReferalID != null
            group c by c.ReferalID into g
            select new {
                Plays = g.Count(), URL = g.Key.ReferalID, MinDate = g.Min(x=>x.Date)
            };
