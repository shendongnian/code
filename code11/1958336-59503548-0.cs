    using (StreamReader r = new StreamReader(filepath))
    {
        var inputString = r.ReadToEnd();
        JToken outer = JToken.Parse(inputString);
        JObject inner = outer["items"]["itemName"]["properties"].Value<JObject>();
        List<string> keys = inner.Properties().Select(p => p.Name).ToList();
        var items = new ExpandoObject() as IDictionary<string, Object>;
        foreach (string k in keys)
        {
            items.Add(k, Convert.ToInt32(outer["items"]["itemName"]["properties"][k]["type"]));
        }
        Console.WriteLine(JsonConvert.SerializeObject(new { items = items }));
    }
