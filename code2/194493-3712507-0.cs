	var symbols = new[] {
		new Symbol { Text = "A", Count=15, Probability=double.NaN, Code=""},
		new Symbol { Text = "B", Count=7,  Probability=double.NaN, Code="" },
		new Symbol { Text = "C", Count=6,  Probability=double.NaN, Code="" },
		new Symbol { Text = "D", Count=6,  Probability=double.NaN, Code="" },
		new Symbol { Text = "E", Count=5,  Probability=double.NaN, Code="" },
	}.ToList();
	Func<IEnumerable<Symbol>, int> totalCount = 
		symbols_ => symbols_.Aggregate(0, (a, s) => a + s.Count);
	var total = totalCount(symbols);
	foreach(var symbol in symbols)
	{
		symbol.Probability = total / symbol.Count;
	}
	//symbols.Sort((a, b) => b.Count.CompareTo(a.Count));
	// Where is the Y-Combinator when you need it ?
	Action<IEnumerable<Symbol>, string, int> recurse = null;
	recurse = (symbols_, str, depth) => {
		if (symbols_.Count() == 1)
		{
			symbols_.Single().Code = str;
			return;
		}
		var bestDiff = int.MaxValue;
		int i;
		for(i = 1; i < symbols_.Count(); i++)
		{
			var firstPartCount = totalCount(symbols_.Take(i));
			var secondPartCount = totalCount(symbols_.Skip(i));
			var diff = Math.Abs(firstPartCount - secondPartCount);
			if (diff < bestDiff) bestDiff = diff;
			else break;
		}
		i = i - 1;
		Console.WriteLine("{0}{1}|{2}", new String('\t', depth),
			symbols_.Take(i).Aggregate("", (a, s) => a + s.Text + " "),
			symbols_.Skip(i).Aggregate("", (a, s) => a + s.Text + " "));
		recurse(symbols_.Take(i), str + "0", depth+1);
		recurse(symbols_.Skip(i), str + "1", depth+1);
	};
	recurse(symbols, "", 0);
	Console.WriteLine(new string('-', 78));
	foreach (var symbol in symbols)
	{
		Console.WriteLine("{0}\t{1}\t{2}\t{3}", symbol.Code, symbol.Text,
			symbol.Count, symbol.Probability);
	}
	Console.ReadLine();
