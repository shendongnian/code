	// Append each item sequentially
	foreach (var item in list_temp)
	{
		using (var fileStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
		{
			MessagePackExtensions.AppendToFile(fileStream, item);
		}
	}
	// Then deserialize the entire sequence as a List<T>>
	using (var fileStream = File.OpenRead(filename))
	{
		var array = MessagePackSerializer.Deserialize<List<struct_realTime>>(fileStream);
		
		Console.WriteLine(MessagePackSerializer.ToJson(array));
		Assert.IsTrue(array.Count == list_temp.Count);
		Assert.IsTrue(list_temp.SequenceEqual(array));
	}
