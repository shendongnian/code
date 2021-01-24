    var clients = Clients.Where(c => c.FirstName.StartsWith("Mark"))
                  .Select(c => new Clients{
                           LastName = c.LastName.ToUpper(),
                           c.DateAdded,
                           c.FirstName,
     })
