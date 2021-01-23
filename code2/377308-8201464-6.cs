	void Main()
	{
		string[] items = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
		
		foreach(var combination in CreateCombinations(items, 5))
			Console.WriteLine("({0})", combination.ToString());
	}
	
	private static IEnumerable<LinkedNode> CreateCombinations(string[] items, int length)
	{
		var nodes = items.Select(item => new LinkedNode { Value = item, Next = null });
		
		for(int i=0; i<length-1; i++)
		{
			nodes = 
				from a in nodes 
				from b in items 
				where a.Value.CompareTo(b) > 0
				orderby b, a.Value
				select new LinkedNode { Value = b, Next = a };
		}
		
		return nodes;
	}
	
	public class LinkedNode
	{
		public string Value { get; set; }
		public LinkedNode Next { get; set; }
		
		public override string ToString()
		{
			if (this.Next == null)
				return this.Value;
				
			return this.Value + ", " + this.Next.ToString();
		}
	}
