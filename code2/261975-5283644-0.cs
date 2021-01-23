try
{
	int packetsize, requestid, serverdata;
	string string1, string2;
	List&lt;byte&gt; str = new List&lt;byte&gt;();
	using (BinaryReader reader = new BinaryReader(clientStream))
	{
		packetsize = reader.ReadInt32();
		requestid = reader.ReadInt32();
		serverdata = reader.ReadInt32();
		Console.WriteLine("Packet Size: {0} RequestID: {1} ServerData: {2}", packetsize, requestid, serverdata);
		byte nextByte = reader.ReadByte();
		while (nextByte != 0)
		{
			str.Add(nextByte);
			nextByte = reader.ReadByte();
		}
		// Password Sent to be Authenticated
		string1 = Encoding.UTF8.GetString(str.ToArray());
		str.Clear();
		nextByte = reader.ReadByte();
		while (nextByte != 0)
		{
			str.Add(nextByte);
			nextByte = reader.ReadByte();
		}
	}
	// NULL string
	string2 = Encoding.UTF8.GetString(str.ToArray());
	Console.WriteLine("String1: {0} String2: {1}", string1, string2);
	// Reply to Authentication Request
	using (MemoryStream stream = new MemoryStream())
	using (BinaryWriter writer = new BinaryWriter(stream))
	{
		writer.Write((int)(1)); // Packet Size
		writer.Write((int)(requestid)); // Mirror RequestID if Authenticated, -1 if Failed
		byte[] buffer = stream.ToArray();
		clientStream.Write(buffer, 0, buffer.Length);
		clientStream.Flush();
	}
}
