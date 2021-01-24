	void Iterate2<T>(T collection)
	where T: IEnumerable
	{
		var enumerator = collection.GetEnumerator();
		if (enumerator is IEnumerator)
			while (enumerator.MoveNext())
			{
				var item = enumerator.Current;
				Console.WriteLine(item.ToString());
			}
	}
