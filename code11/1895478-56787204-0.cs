    		static void Main()
		{
			List<int> options = new List<int>() { 1, 2, 4, 8, 16, 32 };
			List<int> selectedOptions = new List<int>();
			int aggrigatedAnswer = 22;
			BreakDown(aggrigatedAnswer, options, selectedOptions);
			
			Console.Write(string.Join(",", selectedOptions));
		}
		public static int BreakDown(int value, List<int> options, List<int> selectedOptions)
		{
			if (value <= 0)
				return 0;
			else
			{
				int option = options.Where(a => a <= value).Max();
				value -= option;
				selectedOptions.Add(option);
				BreakDown(value, options, selectedOptions);
				return value;
			}
		}
