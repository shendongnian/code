    var prices = Services
        .SelectMany(arg => arg.Prices)
        .GroupBy(arg => arg.Quantity)
        .Select(arg => new { Price = arg.Sum(x => x.Price), Quantity = arg.Key })
        .ToList();
