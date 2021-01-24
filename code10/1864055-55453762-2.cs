	var output = new HashSet<HashSet<string>>(HashSetEqualityComparer<string>.Instance);
	for (int i = 0; i < input.Length; i++)
	{
		// We need to make sure that every input item is in the output
		output.Add(new HashSet<string>(input[i]));
		for (int j = i + 1; j < input.Length; j++)
		{
			// It annoys me that we have to create a HashSet<string>(input[i]))twice
			var hashSet = new HashSet<string>(input[i]);
			hashSet.UnionWith(input[j]);
			output.Add(hashSet);
		}
	}
