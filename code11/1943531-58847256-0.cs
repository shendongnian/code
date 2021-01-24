using System;
using System.Text.RegularExpressions;
public class Program
{
	public static void Main()
	{
		string data = "01234,56789";
		
		var splitPattern = ","; // two results
		string[] processedData = Regex.Split(data, splitPattern);
		Console.WriteLine($"Using {splitPattern} to split {data} yields {processedData.Length} results.");
		foreach (string d in processedData)
		{
			Console.WriteLine(String.Format("[{0}]", d));
		}
		
		splitPattern = "(,)"; // three results (includes the comma itself)
		processedData = Regex.Split(data, splitPattern);
		Console.WriteLine($"Using {splitPattern} to split {data} yields {processedData.Length} results.");
		foreach (string d in processedData)
		{
			Console.WriteLine(String.Format("[{0}]", d));
		}
	}
}
/* Output
Using , to split 01234,56789 yields 2 results.
[01234]
[56789]
Using (,) to split 01234,56789 yields 3 results.
[01234]
[,]
[56789]
*/
As Wiktor commented, you probably should be using Matches instead of Split
