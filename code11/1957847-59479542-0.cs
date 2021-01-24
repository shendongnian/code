using System;
using System.Collections.Generic;
using System.Collections;
					
public class Program
{
	private static string yourString = "12,45,32,34,56,65,44,56,24,43453,3424,3436345,342342,453424,2342,664,43542,234,2346346,6,234,5566";
	public static void Main()
	{
		Console.WriteLine("Using IEnumerable");
		foreach (int item in GetEnumerableIntFromString(yourString))
		{
			Console.WriteLine(item);
		}
		Console.WriteLine("Using List");
		foreach (int item in GetListIntFromString(yourString))
		{
			Console.WriteLine(item);
		}
	}
	
	// Using IEnumerable
	private static IEnumerable<int> GetEnumerableIntFromString(string str)
	{
	    string[] splitString = str.Split(new[]{','},StringSplitOptions.RemoveEmptyEntries);
		foreach(string item in splitString)
		{
			yield return Convert.ToInt32(item);
		}
	}
	
	// Using List
	private static List<int> GetListIntFromString(string str)
	{
		List<int> yourList = new List<int>();
	    string[] splitString = str.Split(new[]{','},StringSplitOptions.RemoveEmptyEntries);
		foreach(string item in splitString)
		{
			yourList.Add(Convert.ToInt32(item));
		}
		return yourList;
	}
}
**Output:**
Using IEnumerable
12
45
32
34
56
65
44
56
24
43453
3424
3436345
342342
453424
2342
664
43542
234
2346346
6
234
5566
Using List
12
45
32
34
56
65
44
56
24
43453
3424
3436345
342342
453424
2342
664
43542
234
2346346
6
234
5566
More information: If you have an `Enumerable` want to **Convert to `List`**:
Enumerable<int> enumerable = yourEnumerable;
List<int> asList = enumerable.ToList();
