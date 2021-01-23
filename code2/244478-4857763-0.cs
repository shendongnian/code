    using (var context = new Entities())
    {
        var people = (from p in c.People.Include("Addresses")
                      select new 
                      {
                          Person = p,
                          AddressCount = p.Addresses.Count
                      }).ToList();
        foreach (var item in people)
        {
            item.Person.AddressCount = item.AddressCount;
        }
    }
