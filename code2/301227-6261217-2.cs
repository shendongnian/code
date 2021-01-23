    var cityList = network.Continents
        .SelectMany(continent => continent.Countries)
        .Where(ctry => ctry.Id == "country")
        .SelectMany(ctry =>
            ctry.Cities.Select(c => new City { Id = c.Id, Name = c.Name })
        ).ToList();
