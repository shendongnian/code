    List<Derived> list = db.Bases.OfType<Derived>().ToList()
    .Select(p => new Derived()
                     {
                         Id = b.Id,
                         PropertyA = b.PropertyA,
                         PropertyB =  SomeCalculation(),
                     }).ToList();;
