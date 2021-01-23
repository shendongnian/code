    List<reportUser> ru = leaders
            .GroupJoin(db.sweeps,
            a => a.FBID.ToString(),
            s => s.userFBID.First().ToString(),
            (a, matching) => 
            {
                var match = matching.FirstOrDefault();
                return match != null ?
                new reportUser
            {
                FBID = a.FBID,
                CurrentPoints = a.CurrentPoints,
                Name = match.Name,
                Email = match.email
            }
            : new reportUser
            {
                FBID = 0, // a.FBID ?
                CurrentPoints = 0, // a.CurrentPoints ?
                Name = "",
                Email = ""
            }})
            .Select(a => a)
            .ToList();
