	class Program
	{
		static void Main(string[] args)
		{
			var d = new[]
			        	{
			        		new
			        			{
			        				Name = "Some",
			        				Number = 1010
			        			},
			        		new
			        			{
			        				Name = "Other",
			        				Number = 2010
			        			}
			        	};
			foreach (var item in d)
			{
				string s = @item.Name;
				int n = @item.Number;
				Console.WriteLine("{0} {1}", s, n);
			}
		}
	}
