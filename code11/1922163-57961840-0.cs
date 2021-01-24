        var shop_object = JsonConvert.DeserializeObject<JObject>(shop_json);
        Console.WriteLine(shop_object);
        try
        {
            if (shop_object.SelectTokens("$..name").Any(t => t.Value<string>() == DesiredItem))
            {
                Console.WriteLine("\n \n The desired item is in stock");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("error keyword");
        }
