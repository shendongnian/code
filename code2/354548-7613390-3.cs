	public static void Print(List<string> list)
	{
		var path = new Stack<string>();
		var count = new Stack<int>();
		path.Push("");
		count.Push(0);
		list.Sort(new Comparison<string>(UrlComparison));
		foreach (var x in list)
		{
			while (!x.StartsWith(path.Peek())) { path.Pop(); count.Pop(); }
			path.Push(x);
			count.Push(count.Pop() + 1);
			foreach(var n in count.Reverse()) Console.Write("{0}.", n);
			Console.WriteLine(" {0}", x);
			count.Push(0);
		}
	}
