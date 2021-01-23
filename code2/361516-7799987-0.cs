        var q = db.tblBadgeUsers
        .Where(c => c.UserID == UserID)
        .GroupBy(c => c.BadgeID)
        .Select(c => new { BadgeCount = c.Count(), TheBadge = c.Key }) // *mod
        .OrderBy(c=> c.TheBadge.OrderID);      // * added
