csharp
public class Source
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("example")]
    public string Example { get; set; }
}
public class ResponseObject
{
    [JsonProperty("_id")]
    public string Id { get; set; }
    [JsonProperty("_source")]
    public Source Source { get; set; }
    [JsonProperty("_type")]
    public string Type { get; set; }
}
<br>
And then parse your response like this
csharp
var data = JsonConvert.DeserializeObject<ResponseObject>(response);
<br>
Hope this will help you
