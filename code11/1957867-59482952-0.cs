using System.IO;
// Your code
static string yourTextFileContent = File.ReadAllText("money.txt");
Step 2: I wrote a method to do your work:
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
					
public class Program
{
    // Demo string
    static string yourMoney = @"28:Toy
1:Chocolate bar
10:Water bottle";
    // Your real string
    //static string yourTextFileContent = File.ReadAllText("money.txt");
	public static void Main()
	{
		Console.WriteLine("Using IEnumerable");
		foreach (int item in GetEnumerableIntFromString(yourMoney))
		{
			Console.WriteLine(item);
		}
	}
	
	// Using IEnumerable
	private static IEnumerable<int> GetEnumerableIntFromString(string str)
	{
        string[] splitLine = str.Split(new[]{'\r','\n'},StringSplitOptions.RemoveEmptyEntries);
		foreach(string item in splitLine)
		{
			string[] splitToGetNumber = item.Split(new[]{':'},StringSplitOptions.RemoveEmptyEntries);
			yield return Convert.ToInt32(splitToGetNumber[0].Trim());
		}
	}
}
If you have an `Enumerable`, you want to Convert to `List`:
Enumerable<int> enumerable = yourEnumerable;
List<int> asList = enumerable.ToList();
