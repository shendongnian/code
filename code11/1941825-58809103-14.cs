	var readList = new List<struct_realTime>();
	using (var fileStream = File.OpenRead(filename))
	{
		while (fileStream.Position < fileStream.Length)
		{
			var item = MessagePackSerializer.Deserialize<struct_realTime>(fileStream);
			readList.Append(item);
		}
	}
	Assert.IsTrue(readList.Count == list_temp.Count);
