    var q = db.tblBadgeUsers
        .Where(c => c.UserID == UserID)
        .GroupBy(c => new { c.BadgeID, c.OrderID })
        .OrderBy(group => group.Key.OrderID)
        .Select(c => new { BadgeCount = c.Count(), TheBadge = c });
