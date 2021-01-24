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
# B. Method
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
#Test
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
#Output
{
  "abc.123.donkey": "hello world",
  "abc.123.kong": 123,
  "abc.meta.aaa": "bbb"
}
