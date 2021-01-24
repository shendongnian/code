    class Program
    {
	static void Main(string[] args)
	{
		_getStats();
	}
	static void _getStats()
	{
		do
		{
			Random rnd = new Random();
			int stat1 = 0;
			int stat2 = 0;
			int stat3 = 0;
			int stat4 = 0;
			int stat5 = 0;
			int stat6 = 0;
			for (int i = 0; i < 6; i++)
			{
				int roll1 = rnd.Next(1, 7);
				int roll2 = rnd.Next(1, 7);
				int roll3 = rnd.Next(1, 7);
				int roll4 = rnd.Next(1, 7);
				int tempStatTotal = 0;
				List<int> rollList = new List<int>();
				rollList.Add(roll1);
				rollList.Add(roll2);
				rollList.Add(roll3);
				rollList.Add(roll4);
				rollList.Sort();
				rollList.RemoveAt(0);
				foreach (int j in rollList)
				{
					tempStatTotal += j;
				}
				if (i == 0)
				{
					stat1 = tempStatTotal;
				}
				else if (i == 1)
				{
					stat2 = tempStatTotal;
				}
				else if (i == 2)
				{
					stat3 = tempStatTotal;
				}
				else if (i == 3)
				{
					stat4 = tempStatTotal;
				}
				else if (i == 4)
				{
					stat5 = tempStatTotal;
				}
				else
				{
					stat6 = tempStatTotal;
				}
			}
			if (stat1 == 18 || stat2 == 18 || stat3 == 18 || stat4 == 18 || stat5 == 18 || stat6 == 18)
			{
				Console.WriteLine(stat1);
				Console.WriteLine(stat2);
				Console.WriteLine(stat3);
				Console.WriteLine(stat4);
				Console.WriteLine(stat5);
				Console.WriteLine(stat6);
				break;
			}
		} while (true);
	}
    }
