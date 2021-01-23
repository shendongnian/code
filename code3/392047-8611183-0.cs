    var q = (from c in db.tblArcadeGamePlays
                join a in db.tblProfiles on c.UserID equals a.UserID
                where c.UserID != 0
                select new {
                    c.UserID,
                    c.tblForumAuthor.Username,
                    a.EmailAddress,
                    Date = (from d in db.tblArcadeGamePlays where d.UserID == c.UserID orderby d.Date descending select new { d.Date}).Take(1).Single().Date
                })
    .Distinct()
    .OrderByDescending(c=>c.Date)
    .Take(12);  
