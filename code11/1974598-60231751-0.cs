using System;
using System.Text;
					
public class Program
{
	public static void Main()
	{
        // produces 4a2b2c2a
		Console.WriteLine(GetConsecutiveGroups("aaaabbccaa"));
	}
	
	private static string GetConsecutiveGroups(string input)
	{		
		var result = new StringBuilder();
		var sb = new StringBuilder();
		
		foreach (var c in input)
		{
			if (sb.Length == 0 || sb[sb.Length - 1] == c)
			{
				sb.Append(c);
			}
			else
			{
				result.Append($"{sb.Length}{sb[0]}");
				sb.Clear();
				sb.Append(c);
			}
		}
		
		if (sb.Length > 0)
		{
			result.Append($"{sb.Length}{sb[0]}");
		}
		
		return result.ToString();
	}
}
  [1]: https://dotnetfiddle.net/FDW9k8
