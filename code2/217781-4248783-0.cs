	string[] items = { "A", "A.B.D", "A", "A.B", "E", "F.E", "F", "B.C" };
	char delimiter = '.';
	var result = (from item in items.Distinct()
	             where !items.Any(other => item.StartsWith(other + delimiter))
	             select item).ToArray();
	foreach (var item in result)
	{
		Console.WriteLine(item);
	}
