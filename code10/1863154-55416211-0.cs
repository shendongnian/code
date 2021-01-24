cs
using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
	private static List<string> lstStr = new List<string>
	{
		"1,2,3,4", 
		"3,4,5", 
		"3,4,5,6,7,8,9"
	};
	
	private static string[] search = new[]{"3", "4"}; // "3,4".Split(',')
	
	public static void Main()
	{
		foreach(var el in lstStr.Where(x => SearchFunction(x, search)))
		{
			Console.WriteLine(el);
		}
	}
	
	private static bool SearchFunction(string listItem, string[] search)
	{
		var hashSet = listItem.Split(',').ToHashSet();
		return search.All(hashSet.Contains);
	}
}
