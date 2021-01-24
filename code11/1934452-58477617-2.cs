	class Program
	{
		static List<Object> objects = new List<Object>();
		static Random _random = new Random((int) DateTime.UtcNow.Ticks);
		static void Main(string[] args)
		{
			var i = 0;
			while (i<1000)
			{
				var rgba = new byte[4];
				_random.NextBytes(rgba);
				objects.Add(new Object(rgba));
				i++;
			}
			foreach (Object o in objects)
			{
				PrintColor(o.color);
			}
			var query = objects.GroupBy(x => x.color.ToArgb())
				.Where(g => g.Count() > 1)
				.Select(y => y.Key)
				.ToList();
			Console.WriteLine($"Duplicates {query.Count}");
		}
		static void PrintColor(Color c)
		{
			Console.WriteLine("R:" + c.R + ", G:" + c.G + ", B:" + c.B + ", A:" + c.A);
		}
	}
