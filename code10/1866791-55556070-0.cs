    string json = File.ReadAllText(@"Path to your json");
    
    List<Quote> quotes = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json)
        .Select(x => new Quote { Symbol = x.Key, Price = x.Value.price  })
        .ToList();
    //-------------Print the result to Console-------------
    
    Console.WriteLine("Symbol\tPrice");
    Console.WriteLine("----------------------");
    foreach (var quote in quotes)
    {
        Console.WriteLine(quote.Symbol +"\t" + quote.Price);
    }
