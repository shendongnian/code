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
           // 4 digits, exactly; and can be found in `Groups[1]`.
  	       Regex r = new Regex(@".*_(\w{2}\d{4}).*", RegexOptions.IgnoreCase);
	  	   Match m = r.Match(filename);
		   return m.Success
			   ? m.Groups[1].ToString()
			   : null; // what should happen here? 
		}
		string[] filenames = 
        {
            "aaa_ab12345.txt",
            "bbb_ab12345.txt",
            "aaa_ac12345.txt",
            "bbb_ac12345",
            "aaa_bbb_ab12345.txt",
            "ae12345.txt" // MyMatcher() return null for this - what should you do if this happens?
        };
		var results = filenames
			.Select(MyMatcher)
			.Distinct();
		
		foreach (var result in results)
		{
			Console.WriteLine(result);
		}
	}
}
Gives:
ab1234
ac1234
This can be refined further, such as pre-compiled regex patterns, encapsulation in a class, etc.
