    var json = File.ReadAllText(filepath);
    
    var jObject = JObject.Parse(json);
    var bids = JArray.Parse(jObject["bids"].ToString());    
    var Sell = bids.Select(x => 
                    new PriceValue
                    {
                        Price = x[0].ToString(),
                        Value = x[1].ToString()
                    })
                    .ToList();
    
    var asks = JArray.Parse(jObject["asks"].ToString());
    var Buy = asks.Select(x =>
                    new PriceValue
                    {
                        Price = x[0].ToString(),
                        Value = x[1].ToString()
                    })
                    .ToList();
