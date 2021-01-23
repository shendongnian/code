    var person = this._context.Persons
      .Include(i => i.Addresses)
      .AsNoTracking()
      .First();
    // if this is a Guid, just do Guid.NewGuid();
    // setting IDs to zero(0) assume the database is using an Identity Column
    person.ID = 0;
    foreach (var address in person.Addresses)
    {
      address.ID = 0;
    }
    this._context.Persons.Add(person);
    this._context.SaveChanges();
