using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
(...)
static IEnumerable<JToken> Traverse(JToken jo)
{
	var children = jo.Children();
	if (!children.Any()) yield return jo; 
	foreach ( var ch in children)
	   foreach( var x in Traverse(ch))
			yield return x;
	}
}
or 
static IEnumerable<JToken> Traverse(JToken jo)
{
	if (!jo.Any()) yield return jo; 
	foreach ( var ch in jo.Children())
	   foreach ( var x in Traverse(ch))
			yield return x;
	}
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
