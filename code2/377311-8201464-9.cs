	void Main()
	{
		string[] items = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
		
		foreach(var combination in CreateCombinations(items, 5))
			Console.WriteLine("({0})", combination.ToString());
	}
	
	private static IEnumerable<LinkedNode> CreateCombinations(string[] items, int length)
	{
		if(length == 1)
			return items.Select(item => new LinkedNode { Value = item, Next = null });
		
		return from a in CreateCombinations(items, length - 1) 
			from b in items 
			where a.Value.CompareTo(b) > 0
			orderby b, a.Value
			select new LinkedNode { Value = b, Next = a };
	}
	
	public class LinkedNode
	{
		public string Value { get; set; }
		public LinkedNode Next { get; set; }
		
		public override string ToString()
		{
			return (this.Next == null) ? Value : Value + ", " + Next.ToString();
		}
	}
