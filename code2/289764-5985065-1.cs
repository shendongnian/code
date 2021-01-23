    cats.Add(new Cat("Felix", "Black", DateTime.Today.AddDays(-1)));
    cats.Add(new Cat("Garfield", "Orange", DateTime.Today.AddDays(-10)));
    
    CatFilter filter = new CatFilter();
    filter.Names.Add("Garfield");
    
    List<Cat> result = GetFilteredCats(filter);
