	using System;
	using System.Linq;
	using System.Collections.Generic;
	public class P
	{
		struct DataItem
		{
			public System.DateTime time;
			public int number;
		}
		public static void Main(string[] args)
		{
			var ItemList = new DataItem[] {} ;
			var groups = ItemList
				.GroupBy(item => item.time.Hour * 60 + (item.time.Minute/15)*15 );
			var sums   = groups
				.ToDictionary(g => g.Key, g => g.Sum(item => item.number));
			// lookups now become trivially easy:
			int slot1900 = sums[1900];
			int slot1915 = sums[1915];
			int slot1930 = sums[1930];
		}
	}
