    var query = _db.Persons.Where(p => p.PersonId == PersonId);
    if (query.Count() > 0)
    {
      var data = query.Join(_db.Users, p => p.UserId, u => u.UserId, (p, u) => new
        {
          Id = p.PersonId,
          Name = p.FirstName + " " + p.LastName,
          Phone = p.Phone,
          Email = u.Email
        }).Single();
      return data;
    }
