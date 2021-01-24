using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
					
public class Program
{
	public static void Main()
	{
		var values = new List<int> { 1, 2, 3, 4 };
		var str = values
			.Select(i => $"UNION ALL SELECT {i} ")
			.Aggregate(new StringBuilder(), (sb, a) => sb.Append(a), s => s.ToString());
		Console.WriteLine(str);
	}
}
[C# fiddle][1]
  [1]: https://dotnetfiddle.net/Tgu3lj
