        from g in dbEntity.GameTypes.Include("Draws")
       where g.IsActive
         let d = g.Draws.Where(o => o.DrawDate > System.DateTime.Now)
                        .OrderBy(o => o.DrawDate)
                        .Take(1)       // Needs to stay a collection
      select new GameType {IsActive = g.IsActive, Draws = d}
