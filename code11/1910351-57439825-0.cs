    var userId = HttpContext.Session.GetInt32("user");
    User user = _context.Users.Where(u => u.id == userId)
        .Include(u => u.Transactions)
        .AsNoTracking()
        .FirstOrDefault();
