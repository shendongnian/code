    var allFooAnon = db.Persons.Select(p => new
    {
      Name = p.Name,
      Websites = p.Websites.Select(q => q.Caption)
    });
    
    var list = new List<Foo>();
    foreach (var anon in allFooAnon)
    {
      list.Add(new Foo
      {
        Name = anon.Name,
        Websites = anon.Websites.ToArray()
      });
    }
