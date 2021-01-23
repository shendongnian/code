	using (var client = new WebClient())
	{
		client.Proxy = new WebProxy("some.proxy.com", 8000);
		using (var reader = new BinaryReader(client.OpenRead("example.com/file.jpg")))
		{
			reader.ReadByte();
			reader.ReadInt32();
			reader.ReadBoolean();
			// etc.
		}
	}
