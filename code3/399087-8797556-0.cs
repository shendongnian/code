    using (MainContext db = new MainContext())
    {
        var latestIds = db.tblArcadeGamePlays.OrderByDescending(c => c.Date).Select(c => c.UserID).Distinct().Take(16); // These are the 16 most recent player Ids.
        // join them here to the rest of those player's data
        var playerData = ... // you'll need to fill in here some by filtering the other data you want using latestIds.Contains
    }
