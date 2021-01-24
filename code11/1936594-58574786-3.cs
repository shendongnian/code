    class Price { public int ProductId; }
    class Product { public int Id; public List<Price> Prices; }
    var products = Enumerable.Range(1, 500_000)
        .Select(n => new Product() { Id = n }).ToList();
    var prices = Enumerable.Range(1, 11_000_000)
        .Select(n => new Price { ProductId = n % products.Count }).ToList();
    var stopwatch = Stopwatch.StartNew();
    var lookup = prices.ToLookup(p => p.ProductId);
    Console.WriteLine($"Duration Lookup: {stopwatch.ElapsedMilliseconds:#,0} msec");
    foreach (var product in products)
    {
        product.Prices = lookup[product.Id]?.ToList();
    }
    Console.WriteLine($"Duration Total: {stopwatch.ElapsedMilliseconds:#,0} msec");
