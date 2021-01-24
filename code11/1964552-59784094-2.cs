	void Iterate<T>(T iterator)
		where T: System.Collections.IEnumerable
	{
		foreach (var item in iterator)
		{
			Debug.WriteLine(item.ToString());
		}
	}
	
