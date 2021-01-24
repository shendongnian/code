    response
    .Data
    .Where(country => country.Cities != null && country.Cities.Any())
    .SelectMany(country => country.Cities)
    .Select(city => new {
      CountryId = city.CountryId,
      CountryName = city.CountryName,
      Districts = city.Districts
    }).ToList();
