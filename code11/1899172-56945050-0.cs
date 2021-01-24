	public static string ReadOuterJson(this JsonReader reader, Formatting formatting = Formatting.None, DateParseHandling? dateParseHandling = null, FloatParseHandling? floatParseHandling = null)
	{
		// If you would prefer a null JSON value to return an empty string, remove this line:
		if (reader.TokenType == JsonToken.Null)
			return null;
		var oldDateParseHandling = reader.DateParseHandling;
		var oldFloatParseHandling = reader.FloatParseHandling;
		try
		{
			if (dateParseHandling != null)
				reader.DateParseHandling = dateParseHandling.Value;
			if (floatParseHandling != null)
				reader.FloatParseHandling = floatParseHandling.Value;
			using (var sw = new StringWriter(CultureInfo.InvariantCulture))
			using (var jsonWriter = new JsonTextWriter(sw) { Formatting = formatting })
			{
				jsonWriter.WriteToken(reader);
				return sw.ToString();
			}
		}
		finally
		{
			reader.DateParseHandling = oldDateParseHandling;
			reader.FloatParseHandling = oldFloatParseHandling;
		}
	}
