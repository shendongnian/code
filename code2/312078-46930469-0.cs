    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		List<int> list1 = new List<int> {1, 2, 3, 4, 5, 6 };
    		List<int> list2 = new List<int> {1, 2, 3 };
    		List<int> list3 = new List<int> {1, 2 };
    		
    		var lists = new IEnumerable<int>[] {list1, list2, list3 };
    		
    		var commons = GetCommonItems(lists);
    		Console.WriteLine("Common integers:");
    		foreach (var c in commons)
    			Console.WriteLine(c);
    		
    	}
    
    	static IEnumerable<T> GetCommonItems<T>(IEnumerable<T>[] lists)
    	{
    		HashSet<T> hs = new HashSet<T>(lists.First());
    		for (int i = 1; i < lists.Length; i++)
    			hs.IntersectWith(lists[i]);
    		return hs;
    	}
    }
