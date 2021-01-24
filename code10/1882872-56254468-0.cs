    var memoryContentStream = new MemoryStream();
    using (var streamWriter = new StreamWriter(memoryContentStream, Encoding.UTF8, 1000, 
    true))
    {
	  using (var jsonTextWriter = new JsonTextWriter(streamWriter))
	  {
		var jsonSerializer = new JsonSerializer();
		jsonSerializer.Serialize(jsonTextWriter, OBJECT);
		jsonTextWriter.Flush();
	  }
    }
    if (memoryContentStream.CanSeek)
    {
	  memoryContentStream.Seek(0, SeekOrigin.Begin);
    }
