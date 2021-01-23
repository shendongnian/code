    var q = db.tblBadgeUsers
        .Where(c => c.UserID == UserID)
        .GroupBy(c => c.BadgeID)
        .Select(c => new { BadgeCount = c.Count(), TheBadge = c })
        .OrderBy(x => x.TheBadge.First().OrderId);
