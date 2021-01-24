csharp
using System;
using System.IO;
using Newtonsoft.Json;
public class Fields
{
    [JsonProperty("System.AreaPath")]
    public string AreaPath { get; set; }
    [JsonProperty("System.TeamProject")]
    public string TeamProject { get; set; }
    [JsonProperty("System.IterationPath")]
    public string IterationPath { get; set; }
}
public class Resource
{
    public Fields Fields { get; set; }
}
class Program
{
    static void Main()
    {
        string json = File.ReadAllText("test.json");
        var resource = JsonConvert.DeserializeObject<Resource>(json);
        Console.WriteLine(resource.Fields.TeamProject);
    }
}
JSON (removed the "resource" part to make it a complete JSON document; I assume you know how to handle this if necessary):
json
{
    "fields": {
        "System.AreaPath": "someData",
        "System.TeamProject": "team project",
        "System.IterationPath": "someData"
     }
}
Output: `team project`
