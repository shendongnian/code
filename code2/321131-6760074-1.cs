	public static byte[] SerializeToBytes<T>(T item)
	{
		var formatter = new BinaryFormatter();
		using (var stream = new MemoryStream())
		{
			formatter.Serialize(stream, item);
			stream.Seek(0, SeekOrigin.Begin);
			return stream.ToArray();
		}
	}
----------
	public static object DeserializeFromBytes(byte[] bytes)
	{
		var formatter = new BinaryFormatter();
		using (var stream = new MemoryStream(bytes))
		{
			return formatter.Deserialize(stream);
		}
	}
