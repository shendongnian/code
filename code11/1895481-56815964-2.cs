	enum Dummy { }
	
	static readonly Dummy[] dummies = new[] { 1, 2, 4, 8, 16, 32 }.Select(d => (Dummy)d).ToArray();
	
	public static void Main()
	{
		var i = 11;
		var answers = GetCombination(i);
		Console.WriteLine(string.Join(", ", answers));
	}
	
	static int[] GetCombination(int i)
	{
		var dummy = (Dummy)i;
		return dummies.Where(d => dummy.HasFlag(d)).Cast<int>().ToArray();
	}
