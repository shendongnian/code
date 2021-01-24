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
	""abc"": {
		""123"": {
			""donkey"": ""hello world"",
			""kong"": 123
		},
		""meta"": {
			""aaa"": ""bbb""
		}
	}
}";
var d = GetFlat(json);
var options2 = new JsonSerializerOptions { WriteIndented = true };
Console.WriteLine(JsonSerializer.Serialize(d, options2));
## Output
{
  "abc.123.donkey": "hello world",
  "abc.123.kong": 123,
  "abc.meta.aaa": "bbb"
}
# B. Json.NET
You can do with [Json.NET](https://www.newtonsoft.com/json).
---
## B1. `SelectTokens`
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
(...)
JObject jo = JObject.Parse(json);
var d = jo.SelectTokens("$..*")
	.Where(t => t.HasValues == false)
	.ToDictionary(k => k.Path, v => v);
Console.WriteLine(JsonConvert.SerializeObject(d, Formatting.Indented));
Output
{
  "abc.123.donkey": "hello world",
  "abc.123.kong": 123,
  "abc.meta.aaa": "bbb"
}
## B2. `JToken` traversal
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
(...)
static IEnumerable<JToken> Traverse(JToken jo)
{
	if (!jo.Any()) yield return jo;
	foreach (var ch in jo)
		foreach (var x in Traverse(ch))
			yield return x;
}
### Test
var json = @"{
""abc"": {
	""123"": {
		""donkey"": ""hello world"",
		""kong"": 123
	},
	""meta"": {
		""aaa"": ""bbb""
	}
}
}";
JObject jo = JObject.Parse(json);
var d = Traverse(jo).ToDictionary(k => k.Path, v => v);
var json2 = JsonConvert.SerializeObject(d, Formatting.Indented);
Console.WriteLine(json2);
### Output
{
  "abc.123.donkey": "hello world",
  "abc.123.kong": 123,
  "abc.meta.aaa": "bbb"
}
