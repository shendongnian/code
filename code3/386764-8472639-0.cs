	Action<IEnumerable<Person>, int> traverseAndPrint = null;
	traverseAndPrint =
		(ps, i) =>
		{
			foreach (var p in ps)
			{
				Console.WriteLine("{0}-{1}", new string(' ', i), p.Name);
				
				if (p is Parent) traverseAndPrint(((Parent)p).Children, i + 1);
			}
		};
	
	traverseAndPrint(new [] {ancestor}, 0);
