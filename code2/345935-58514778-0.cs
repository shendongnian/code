using System.Linq;
using System.Text.Json;
(...)
static Dictionary<string, JsonElement> GetFlat(string json)
    {
        using (JsonDocument document = JsonDocument.Parse(json))
        {
            return document.RootElement.EnumerateObject()
                .SelectMany(p => GetLeaves(null, p))
                .ToDictionary(k => k.Path, v => v.P.Value.Clone()); //Clone so that we can use the values outside of using
        }
    }
    static IEnumerable<(string Path, JsonProperty P)> GetLeaves(string path, JsonProperty p)
    {
        path = (path == null) ? p.Name : path + "." + p.Name;
        if (p.Value.ValueKind != JsonValueKind.Object)
            yield return (Path: path, P: p);
        else
            foreach (JsonProperty child in p.Value.EnumerateObject())
                foreach (var leaf in GetLeaves(path, child))
                    yield return leaf;
    }
## Test
using System.Linq;
using System.Text.Json;
(...)
var json = @"{
    ""name"": ""test"",
    ""father"": {
            ""name"": ""test2"", 
         ""age"": 13,
         ""dog"": {
                ""color"": ""brown""
         }
        }
    }";
var d = GetFlat(json);
var options2 = new JsonSerializerOptions { WriteIndented = true };
Console.WriteLine(JsonSerializer.Serialize(d, options2));
## Output
{
  "name": "test",
  "father.name": "test2",
  "father.age": 13,
  "father.dog.color": "brown"
}
