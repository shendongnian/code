csharp
    dynamic reply = new System.Dynamic.ExpandoObject();
    reply.name = "John";
    reply.wins = 42;
    string json = Newtonsoft.Json.JsonConvert.SerializeObject(reply);
    System.Console.WriteLine(json);
