    List<Quote> quotes = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(json)
        .Select(x => new Quote
        {
            Symbol = x.Key,
            Price = Convert.ToDouble(x.Value["price"])
        })
        .ToList();
