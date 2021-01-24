c#
async Task Main()
{
	var json = @"
	{ items: [
	{
	  ""name"": ""http://request.to.website1"", 
	  ""name2"": ""value2"", 
	  ""type"":  ""http://request.to.website1""
	},
	{
	  ""name"": ""http://request.to.website2"",
	  ""name2"": ""value2"",
	  ""type"": ""http://request.to.website1""
	}
	] }";
	var jObject = JObject.Parse(json);
	
	using(var client = new System.Net.Http.HttpClient())
	{
		foreach (JObject o in jObject["items"].AsEnumerable())
		{
			foreach (var token in o)
			{
				var url = token.Value.Value<string>();
				
				if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
				{
					o[token.Key] =  "new content"; // await client.GetStringAsync(url);
				}
			}
		}
	}
	
	var modifiedJson = jObject.ToString();
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/qEK24.png
