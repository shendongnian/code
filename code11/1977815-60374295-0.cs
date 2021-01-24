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
JSON:
json
{
    "fields": {
        "System.AreaPath": "someData",
        "System.TeamProject": "team project",
        "System.IterationPath": "someData"
     }
}
Output: `team project`
