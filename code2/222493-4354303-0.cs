    var topThreeFastestCarManufacturers =
      GetAllCars()
      .GroupBy(c => c.Manufacturer)
      .Select(g => g.OrderByDescending(c => c.TopSpeed).First())
      .OrderByDescending(c => c.TopSpeed)
      .Take(3);
