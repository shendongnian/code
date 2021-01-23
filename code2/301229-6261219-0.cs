    var cities = network.Continents
        .SelectMany(continent => continent.Countries)
        .Where(ctry => ctry.Id == "country")
        .SelectMany(ctry => ctry.Cities)
        .Select(cty=> new City{Id = cty.Id, Name = cty.Name }).ToList<City>();
