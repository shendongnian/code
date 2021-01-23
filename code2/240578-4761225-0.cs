    using (var client = new WebClient())
    using (var stream = client.OpenRead(originGetterURL))
    using (var reader = new StreamReader(stream))
    {
        var jObject = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());
        var encryptionKey = (string)jObject["key"];
        var originURL = (string)jObject["origin_url"];
    }
