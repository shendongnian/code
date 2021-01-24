using System;
using System.Linq;
using System.Text.RegularExpressions;
public class Program
{
	public static void Main()		
	{
		string MyMatcher(string filename)
		{
           // this pattern may need work depending on what you need - it says
           // extract that pattern between the "()" which is 2 characters and
           // 4 digits, exactly, and can be found in `Group[1]`.
  	       Regex r = new Regex(@".*_(\w{2}\d{4}).*", RegexOptions.IgnoreCase);
	  	   Match m = r.Match(filename);
		   return m.Success
			   ? m.Groups[1].ToString()
			   : null;
		}
		string[] filenames = {"aaa_ab12345.txt", "bbb_ab12345.txt", "aaa_ac12345.txt", "bbb_ac12345"};
		var results = filenames
			.Select(MyMatcher)
			.Distinct();
		
		foreach (var result in results)
		{
			Console.WriteLine(result);
		}
	}
}
This can be refined further, such as pre-compiled regex patterns, encapsulating in a class, etc.
