var newJson = JsonSerializer.Serialize(payload, new JsonSerializerOptions 
                           { WriteIndented = true,IgnoreNullValues =true });
The *real* solution though would be to get rid of all that code. It *hampers* the use of System.Text.Json. Left by itself, ASP.NET Core uses Pipelines to read the input stream *without* allocating, deserializes the payload and calls the method with the deserialized object as a parameter, using minimal allocations. Any return values are serialized in the same way.
The question's code though allocates a lot - it caches the input in the StreamReader, then the entire payload is cached in the `payloadString` and then again, as the `payload` object. The reverse process also uses temporary strings. This code takes *at least* twice as much RAM as ASP.NET Core would use.
The action code should be just :
[HttpPost("{eventType}")]
public async Task<IActionResult> ProcessEventAsync([FromRoute] string eventType,
                                                   MyApiData payload)
{
    Guid messageID = Guid.NewGuid();
    payload.Data.Id = messageID.ToString();
    return Accepted(payload);
}
Where `MyApiData` is a strongly-typed object. The shape of the Json example corresponds to :
public class Attributes
{
    public string source { get; set; }
    public string instance { get; set; }
    public string level { get; set; }
    public string message { get; set; }
}
public class Data
{
    public string type { get; set; }
    public Attributes attributes { get; set; }
}
public class MyApiData
{
    public Data data { get; set; }
    public Data[] included {get;set;}
}
All other checks are performed by ASP.NET Core itself - ASP.NET Core will reject any `POST` that doesn't have the correct MIME type. It will return a 400 if the request is badly formatted. It will return a 500 if the code throws
