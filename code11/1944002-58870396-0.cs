public class Action
{
    [JsonProperty("tstamp")]
    public DateTimeOffset Tstamp { get; set; }
    [JsonProperty("text")]
    public string Text { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
}
NOTE:
How did I find the answer? I removed different sections of the JSON and ran the code until I found the error. When I found out which section of the JSON was causing the problem I checked the object where that was defined and looked for the matching class. When I didn't find a class defined for that object in your code, I added it.
You should try and minimise the problem to as small a code as possible i.e. remove sections of you JSON. This will remove the parts that do work and isolate the exact code/JSON that is failing.
Hope that helps :-)
