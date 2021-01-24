    var query = await _db.Countries
        .Include(c => c.Cities)
        .Include(c => c.Mountains)
        .Include(c => c.Rivers)
        .Where(c => c.Cities.Any(city => city.Population > 10000)
            || c.Mountains.Any(mountain => mountain.Heigh > 1000)
            || c.River.Any(river => river.Length > 100000))
        .Where(c => c.Cities.Any() || c.Mountains.Any() || c.Rivers.Any())
        .ToListAsync();
    
    var totalCount = query.Count();
    
    var countries = query
        .Select(country => new CountryDto
        {
            CountryName = country.Name,
            CityDtos = country.Citites
                .Select(city => new CityDto
                {
                    Name = city.Name,
                }),
            MountainDtos = country.Mountains
                .Select(mountain => new MountainDto
                {
                    Name = mountain.Name,
                }),
            RiverDtos = country.Rivers
                .Select(river => new RiverDto
                {
                    Name = river.Name,
                }),
        })
        .ToList();
