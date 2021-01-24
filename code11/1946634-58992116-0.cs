	public SomeConfig ReadEncryptedConfiguration(string inputFile, string password)
	{
		using (var stream = CreateStream(inputFile, password))
		{
			var ser = new XmlSerializer(typeof(SomeConfig));
			var config = ser.Deserialize(stream);
			return config;
		}
	}
