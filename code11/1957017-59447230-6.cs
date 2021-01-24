	static List<string> GetComments(string jsonString)
	{
		var options = new JsonReaderOptions 
		{ 
			CommentHandling = JsonCommentHandling.Allow 
		};
		var list = new List<string>();
		var reader = new Utf8JsonReader(new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(jsonString)), options);
		while (reader.Read())
			if (reader.TokenType == JsonTokenType.Comment)
				list.Add(reader.GetComment());
		return list;
	}
