    return (from c in db.tblGPlusOneClicks
            where c.UserID == UserID
            group c by c.URLID into g
            where g.OrderByDescending(x => x.Date).First().IsOn
            select g.Key).Distinct().Count();
