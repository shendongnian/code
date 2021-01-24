	public void Read_WhenCalledWithSerializedDateTime_ThenReturnDeserializedDateTime()
	{
		var a = "{\r\n \"PublikationsDatum\": \"/Date(1573581177000)/\" \r\n}";
		var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(a), false, new JsonReaderState(new JsonReaderOptions()));
		while (utf8JsonReader.Read())
			if (utf8JsonReader.TokenType == JsonTokenType.String)
				break;
		var deserializedDateTime = this.testee.Read(ref utf8JsonReader, typeof(DateTime), new JsonSerializerOptions {IgnoreNullValues = true});
	}
