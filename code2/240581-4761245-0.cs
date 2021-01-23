    using (WebClient client = new WebClient())
    {
        Stream stream = client.OpenRead(originGetterURL); StreamReader reader = new  StreamReader(stream);
        JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine()); string encryptionKey = (string)jObject["key"]; string originURL = (string)jObject["origin_url"];
        stream.Close() reader.Close()
    } // 'client' instance gets disposed here
