    // Consider whether you want DateTime.UtcNow. Will depend on your storage
    DateTime renewalCutoff = DateTime.Now.AddHours(-24);
    using(var context = Entities())
    {
        var persons = from p in context.Persons
                      select new Person
                      {
                          Name = p.Name,
                          HasRenewedPassword = p.LastRenewedPassword > renewalCutoff
                      }
    }
