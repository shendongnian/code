    var x = ParentTable.Select(z=> new {
    z.Id,
    z.Foo,
    z.ParentIDChildTable.OrderBy(c=> c.Date).First().ID,
    z.ParentIDChildTable.OrderBy(c=> c.Date).First().Foo,
    z.ParentIDChildTable.OrderBy(c=> c.Date).First().Date
     
    }
