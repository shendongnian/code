	static void Main(string[] args)
	{
		Random R = new Random();
		List<List<int>> sets = new List<List<int>>();
		for(int s=1; s<=5; s++)
		{
			List<int> set = new List<int>();
			for (int i = 1; i <= 5; i++)
			{
				set.Add(R.Next(1, 20));
			}
			set.Sort();
			set.Reverse();
			sets.Add(set);
		}
		foreach(List<int> set in sets)
		{
			Console.WriteLine(string.Join(", ", set));
		}
		Console.Write("Press Enter to quit");
		Console.ReadLine();
	}
