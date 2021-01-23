	public static void Print(List<string> list)
	{
		var path = new Stack<string>();
		var count = new Stack<int>();
		path.Push("");
		count.Push(0);
		list.Sort();
		foreach (var x in list)
		{
			while (!x.StartsWith(path.Peek())) { path.Pop(); count.Pop(); }
			path.Push(x);
			count.Push(count.Pop() + 1);
			for (int i = 2; i < path.Count; i++) Console.Write("    ");
			Console.WriteLine("{0}. {1}", count.Peek(), x);
			count.Push(0);
		}
	}
