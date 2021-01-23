	Dictionary<int, bool> set = new Dictionary<int, bool>();
	char[] buffer = new char[3];
	int count = 0;
	for (int c1 = (int)'A'; c1 <= (int)'z'; c1++)
	{
		buffer[0] = (char)c1;
		for (int c2 = (int)'A'; c2 <= (int)'z'; c2++)
		{
			buffer[1] = (char)c2;
			for (int c3 = (int)'A'; c3 <= (int)'z'; c3++)
			{
				buffer[2] = (char)c3;
				string str = new string(buffer);
				count++;
				int hash = str.GetHashCode();
				if (set.ContainsKey(hash))
				{
					Console.WriteLine("Collision for {0}", str);
				}
				set[hash] = false;
			}
		}
	}
	Console.WriteLine("Generated {0} of {1} hashes", set.Count, count);
