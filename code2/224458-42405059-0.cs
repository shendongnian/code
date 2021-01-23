	int partLength = 35;
	string sentence = "Silver badges are awarded for longer term goals. Silver badges are uncommon.";
	List<string> lines =
		sentence
			.Split(' ')
			.Aggregate(new [] { "" }.ToList(), (a, x) =>
			{
				var last = a[a.Count - 1];
				if ((last + " " + x).Length > partLength)
				{
					a.Add(x);
				}
				else
				{
					a[a.Count - 1] = (last + " " + x).Trim();
				}
				return a;
			});
