    query = personList.SelectMany(p => p.Animal.Where(a => a.Name == "Cat")
                      .SelectMany(a => p.Toys.Select(t => new
                      {
                          p.Id,
                          toy = t
                      })));
