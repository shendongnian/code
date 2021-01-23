		public class CategoryComparer : Comparer<Category>
		{
			public override int Compare(Category x, Category y)
			{
				var xParts = x.prefix.Split(new[] { '.' });
				var yParts = y.prefix.Split(new[] { '.' });
				int index = 0;
				while (true)
				{
					bool xHasValue = xParts.Length > index;
					bool yHasValue = yParts.Length > index;
					if (xHasValue && !yHasValue)
						return 1;	// x bigger
					if (!xHasValue && yHasValue)
						return -1;	// y bigger
					if (!xHasValue && !yHasValue)
						return 0;	// no more values -- same
					var xValue = decimal.Parse("." + xParts[index]);
					var yValue = decimal.Parse("." + yParts[index]);
					if (xValue > yValue)
						return 1;	// x bigger
					if (xValue < yValue)
						return -1;	// y bigger
					index++;
				}
			}
		}
		public static void Main()
		{
			var categories = new List<Category>()
			{
				new Category { prefix = "1" },
				new Category { prefix = "2.2" },
				new Category { prefix = "1.1.1" },
				new Category { prefix = "1.1.1" },
				new Category { prefix = "1.001.1" },
				new Category { prefix = "3" },
			};
			categories.Sort(new CategoryComparer());
			foreach (var category in categories)
				Console.WriteLine(category.prefix);
		}
