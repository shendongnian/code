	static readonly Dictionary<char,int> dict = new Dictionary<char,int>
	{
		['a'] = 1,
		['b'] = 2,
		['c'] = 4,
		['d'] = 8,
		['e'] = 16,
		['f'] = 32
	};
	
	public static void Main()
	{
		var i = 11;
		var answers = GetCombination(i);
		Console.WriteLine($"Letters: {string.Join(", ", answers.Keys)}");
		Console.WriteLine($"Numbers: {string.Join(", ", answers.Values)}");
	}
	
	static Dictionary<char,int> GetCombination(int i) =>
		dict.Where(p => (p.Value & i) == p.Value).ToDictionary(p => p.Key, p => p.Value);
