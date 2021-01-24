    var result = listOfCustomTypes.GroupBy(i => i.DateTime)
                                  .Select(g => new YourClass {
                                      Date = g.Key,
                                      SomeProperty1 = g.Average(i => i.SomeProperty1),
                                      SomeProperty2 = g.Average(i => i.SomeProperty2),
                                  });
