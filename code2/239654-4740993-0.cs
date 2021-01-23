	public byte[] Serialize(object myObject)
	{
        MemoryStream stream = new MemoryStream()
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(stream, myObject);
			stream.Seek(0, SeekOrigin.Begin);
			byte[] result = stream.ToArray();
			stream.Close();
			return result;
	}
