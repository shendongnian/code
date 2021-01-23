     var persons = Enumerable.Range(0, data.Count / 2)
                             .Select(i => new Person
                                              {
                                                 Name = data[2 * i],
                                                 Surname = data[2 * i + 1] 
                                              })
                             .ToList();
