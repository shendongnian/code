		List<string> phones = new List<string>();
		List<string> addresses = new List<string>();
		List<string> names = new List<string>();
        // fill with data
		List<Tuple<string,string,string>> results = new List<Tuple<string, string, string>>();
		// aggregate with data - if only two you could also use Zip()
		for (int i = 0; i < names.Count; i++)
		{
			results.Add(Tuple.Create(names[i], addresses[i], phones[i]));
		}
