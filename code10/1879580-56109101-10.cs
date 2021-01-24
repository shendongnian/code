    IQueryable<Human> queryAmericans = myDbContext.Humans
        .Where(human => human.Country == "USA")
        .OrderByDescending(human => human.Age);
    List<Human> americans = queryAmericans.ToList();
    var oldestSpecialAmerican = americans
        .Where(american => american.IsSpecial())
        .FirstOrDefault();
