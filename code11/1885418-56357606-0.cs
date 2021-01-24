		const string json = @"{""spec"": { ""SOMETHING WITH SPACES"" : ""10"", ""SOMETHING WITH MORE SPACES"" : ""20"" }}";
		dynamic data = JsonConvert.DeserializeObject(json);
		Dictionary<string, string> list = data["spec"].ToObject<Dictionary<string, string>>();
		foreach (var item in list)
		{
			Console.WriteLine(item.Key + ", " + item.Value);
		}
