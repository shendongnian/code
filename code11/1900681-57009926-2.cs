cs
private static IEnumerable<Foo> ReplaceFirst(IEnumerable<Foo> source, Foo target)
{
	bool found = false;
	foreach (var item in source)
	{
		if (found)
		{
			yield return item;
		}
		else if (EqualityComparer<Foo>.Default.Equals(item, target))
		{
			found = true;
			yield return new Foo();
		}
		else
		{
			yield return item;
		}
	}
	if (!found)
	{
		throw new InvalidOperationException("not found");
	}
}
