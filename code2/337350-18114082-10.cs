    dbContext.Entry(person).State = EntityState.Detached;
    person.ID = 0;
    foreach (var address in person.Addresses)
    {
      dbContext.Entry(address).State = EntityState.Detached;
      address.ID = 0;
    }
    this._context.Persons.Add(person);
    this._context.SaveChanges();
