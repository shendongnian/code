	var callingAssembly = Assembly.GetCallingAssembly();
	var bytes = File.ReadAllBytes(callingAssembly.Location);
	const int intToFind = 42;
	var indexes = bytes.AllIndexesOf(intToFind);
	foreach (var index in indexes)
	{
		Console.WriteLine(index);
	}
