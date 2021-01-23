    var set = new[]
                  {
                      new {Name = "x", Date = new DateTime(2000, 1, 1), Value = 1,},
                      new {Name = "x", Date = new DateTime(2001, 1, 1), Value = 2,},
                      new {Name = "y", Date = new DateTime(2000, 1, 1), Value = 3,},
                  };
    
    var query =
        from x in set
        orderby x.Date descending
        group x by x.Name
        into g
        select g.First();
    
    Console.WriteLine(query.First().Date);
