    var userId = HttpContext.Session.GetInt32("user");
    User user = _context.Users
        .AsNoTracking()
        .Where(u => u.id == userId)
        .Select(u => new User
        {
            //Select all properties like this :
            FirstName = u.FirstName,
            LastName = u.LastName,
            //... Other properties,
            Transactions = u.TransActions.Select(t => new TransationViewModel
            {
                //Select all properties like this :
                //Name = t.Name
            }).ToList()
        })
        .FirstOrDefault();
