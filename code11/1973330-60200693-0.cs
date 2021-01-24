	[HttpGet]
	[Route("{key}")]
	public ResponseType SearchObjects([FromUri] string key, [FromUri] Dictionary<string, string> options)
	{
		AddMatchingQueryParamsToDictionary(Request, nameof(options), options);
		//options are now ready to use
	}
	/// <summary>
	/// Fills the dictionary with additional values found in query parameters
	/// In the query parameters given by the request, dictionary items will be in the format "dictName.dictKey".
	/// </summary>
	private static void AddMatchingQueryParamsToDictionary(HttpRequestMessage request, string dictionaryModelName, IDictionary<string, string> dictionaryToFill)
	{
		var queryParams = request.GetQueryNameValuePairs();
		queryParams
			.Where(pair => pair.Key.StartsWith(dictionaryModelName))
			.Select(pair =>
			{
				var key = pair.Key;
				var index = key.IndexOf(dictionaryModelName, StringComparison.InvariantCultureIgnoreCase);
				var newKey = index < 0 ? key : key.Remove(index, dictionaryModelName.Length + 1 /*the dot*/);
				return (key: newKey, value: pair.Value);
			}).ToList()
			.ForEach(pair => dictionaryToFill[pair.key] = pair.value);
	}
