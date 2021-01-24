    // .ToList will perform a query to your DB
    var sessions = dbContext.Session.Where(s => s.UserId == id).ToList();
    if (sessions.Count() != 0) {
        // IMO the "check" isnt necessary anymore, unless you perform some operation on the else case
        dbContext.RemoveRange(sessions);
    }
    dbContext.Remove(user);
    dbContext.SaveChanges();
