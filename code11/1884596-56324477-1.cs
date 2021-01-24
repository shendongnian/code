    void Print<T>(string fv, IEnumerable<T> A, string top)
        where T : IPrintable
    {
        foreach (var item in A)
		{
			Console.WriteLine(item.Name + ": " + item.Description);
		}
    }
