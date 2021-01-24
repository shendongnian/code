    {{{{1,7,23,29},{5}},{{3,9,87,21}}},{{{4,8,34,56}},{{78},{30}}}}
.
	public static void Main()
	{
		int[] input = new int[]{1, 3, 4, 5, 7, 8, 9, 23, 34, 56, 78, 87, 29, 21, 2*3*5};
		
		// TREE
		var groupedTree = input.GroupBy(x => x % 2 == 0)
			.Select(g => g.GroupBy(x => x % 3 == 0)
			.Select(h => h.GroupBy(x => x % 5 == 0)));
		
		Console.WriteLine(Display(groupedTree));
	}
	
	// Hack code to dump the tree
	public static string DisplaySequence(IEnumerable items) => "{" + string.Join(",", items.Cast<object>().Select(x => Display(x))) + "}";
	public static string Display(object item) => item is IEnumerable seq ? DisplaySequence(seq) : item.ToString();
