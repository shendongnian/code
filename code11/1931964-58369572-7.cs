    using Newtonsoft.Json.Linq;
    (...)
    JObject o = JObject.Parse(json);
    
    var rs = o["results"];
    foreach (var r in rs)
    {
        Console.WriteLine("-----");
        Console.WriteLine(r);
    }
