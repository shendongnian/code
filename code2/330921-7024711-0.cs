	class Program
	{
		static void Main(string[] args)
		{
			var myList = new List<string>;
			using (var sw = new StreamReader(@"c:\foo.txt"))
			{
				while (true)
				{
					string line = sw.ReadLine();
					if (line == null)
						break;
					myList.Add(line);
				}
			}
		}
	}
