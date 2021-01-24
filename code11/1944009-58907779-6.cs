	// Usings:
	//  using ProtoBuf;
	
	var map = GenerateMap();
	byte[] serbytes;
	using (var ms = new MemoryStream())
	{
		using (var cmp = new GZipStream(ms, CompressionLevel.Optimal, true))
		{
			Serializer.Serialize(ms, map);
		}
		serbytes = ms.ToArray();
	}
	Map deser;
	using (var ms = new MemoryStream(serbyte))
	using (var dec = new GZipStream(ms, CompressionMode.Decompress, true))
	{
		deser = Serializer.Deserialize<Map>(ms);
	}
