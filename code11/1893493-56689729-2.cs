    using System;
    using System.Text.RegularExpressions;
    public class Test
    {
    	public static void Main()
    	{
    		var s = "[Whatever You Want (WYW)]";
            Console.WriteLine(Regex.Replace(s, @"\(([^()]*)\)", "(<b>$1</b>)"));
    	}
    }
