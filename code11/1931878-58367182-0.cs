	private static Dictionary<char, int> preComputed = new Dictionary<char, int> ();
	
	public static void Main()
	{
		var result = SquareDigits(9119);
		Console.WriteLine(result);
	}
	
	private static string SquareDigits(uint input)
	{
		return string.Join(string.Empty, input.ToString().Select(x => Square(x)));
	}
	
	private static int Square(char	x) {
		if (preComputed.ContainsKey(x))
		{
			return preComputed[x];
		}
		
		var numberX = Int32.Parse(x.ToString());
		var squared = numberX* numberX;
		preComputed[x] = squared;
		return squared;
	}
