    List<Derived> list = db.Bases.ToList()
    .Select(p => new Derived()
                     {
                         Id = b.Id,
                         PropertyA = b.PropertyA,
                         PropertyB =  SomeCalculation(),
                     }).ToList();;
