    string str = "{'data': {'someProperty': 0.00001}}";
    var serializer = new JsonSerializer { FloatParseHandling = FloatParseHandling.Decimal };
    using (System.IO.TextReader tr = new System.IO.StringReader(str))
    using (var jsonReader = new JsonTextReader(tr))
    {
                
        var jObject = JObject.Load(jsonReader);
        Console.WriteLine(jObject["data"]["someProperty"].Value<decimal>());
    }
// output: 0.00001
