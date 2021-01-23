    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    struct MyDate { public int? Year, Month, Day, Hour, Minute; }
    
    class Program
    {
        static void Main(string[] args)
        {
    		var rx = new Regex(@"^(?<year>\d{4})?-(?<month>\d\d)?-(?<day>\d\d)?T(?<hour>\d\d)?:(?<minute>\d\d)?$");
    
    		Match match = rx.Match("2011-11-07T11:17");
    		if (match.Success)
    		{
    			MyDate result;
    			if (match.Groups["year"].Matched)
    				result.Year = Int32.Parse(match.Groups["year"].Value);
    			if (match.Groups["month"].Matched)
    				result.Year = Int32.Parse(match.Groups["month"].Value);
    			if (match.Groups["day"].Matched)
    				result.Year = Int32.Parse(match.Groups["day"].Value);
    			if (match.Groups["hour"].Matched)
    				result.Year = Int32.Parse(match.Groups["hour"].Value);
    			if (match.Groups["minute"].Matched)
    				result.Year = Int32.Parse(match.Groups["minute"].Value);
    		}
    	}
    }
     
