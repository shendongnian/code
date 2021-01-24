    _yourDataBaseContext.Set<User>()
    .Select(it=> new User
    {
         Name = it.Name,
         Surname = it.Surname,
         Entries = it.Entries.ToList().Where(e=> e.Timestamp > x && e.Timestamp <y)
    })
    .Include("Entries")
    .ToList();
