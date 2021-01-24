	public void Read_WhenCalledWithSerializedDateTime_ThenReturnDeserializedDateTime()
	{
		var a = "\"/Date(1573581177000)/\"";
		var utf8JsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(a), false, new JsonReaderState(new JsonReaderOptions()));
		// Reader always starts out without having read anything yet, so TokenType == JsonTokenType.None initially
		Assert.IsTrue(utf8JsonReader.TokenType == JsonTokenType.None);
		utf8JsonReader.Read();
		var deserializedDateTime = this.testee.Read(ref utf8JsonReader, typeof(DateTime), new JsonSerializerOptions {IgnoreNullValues = true});
	}
