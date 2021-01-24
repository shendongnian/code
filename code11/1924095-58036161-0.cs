    var users = UserContext
        .User
        .AsQueryable()
        .Where
        (
            i => i.id == id
        )
        .ToList();
    if (users.Count != 1)
    {
        return NotFound();
    }
    else
    {
        return users.Single();
    }
