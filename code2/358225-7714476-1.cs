    // As noted in comments, there are serious problems with this approach
    // unless you store everything in UTC (or local time with offset).
    DateTime renewalCutoff = DateTime.UtcNow.AddHours(-24);
    using(var context = Entities())
    {
        var persons = from p in context.Persons
                      select new Person
                      {
                          Name = p.Name,
                          HasRenewedPassword = p.LastRenewedPassword > renewalCutoff
                      };
    }
