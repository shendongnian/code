	class Item
	{
	   int Value { get; }
	   DateTimeOffset Start { get; }
	   DateTimeOffset End { get; }
	}
	public static class EnumerableExtensions
	{
		public static IEnumerable<Item> WithUpdate<Item>(this IEnumerable<Item> enumerable)
		{
			using(var enumerator = enumerable.GetEnumerator())
			{
				var previous = (Item)enumerator.Current;
				while(enumerator.MoveNext())
				{
					if(previous.End>=((Item)enumerator.Current).Start){
						previous.End=((Item)enumerator.Current).Start.AddDays(-1);
					}
					yield return previous;
					previous = (Item)enumerator.Current;
				}
			}
		}
	}
	var items = new List<Item>{ ..............};
	foreach(var item in items.WithUpdate())
	{
		.............
	}
