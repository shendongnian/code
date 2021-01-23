    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    struct MyDate 
    { 
    	public int? Year, Month, Day, Hour, Minute; 
    
    	public override string ToString()
    	{
    		return string.Format("{0}-{1}-{2}T{3}:{4}", Year, Month, Day, Hour, Minute);
    	}
    }
    
    class Program
    {
    	private static readonly Regex dtRegex = new Regex(
    		@"^(?<year>\d{4})?-(?<month>\d\d)?-(?<day>\d\d)?T(?<hour>\d\d)?:(?<minute>\d\d)?$",
    		RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
    
        static void Main(string[] args)
        {
    		Match match = dtRegex.Match("2011-11-07T11:17");
    		if (match.Success)
    		{
    			MyDate result;
    			if (match.Groups["year"].Success)
    				result.Year = Int32.Parse(match.Groups["year"].Value);
    			if (match.Groups["month"].Success)
    				result.Month = Int32.Parse(match.Groups["month"].Value);
    			if (match.Groups["day"].Success)
    				result.Day = Int32.Parse(match.Groups["day"].Value);
    			if (match.Groups["hour"].Success)
    				result.Hour = Int32.Parse(match.Groups["hour"].Value);
    			if (match.Groups["minute"].Success)
    				result.Minute = Int32.Parse(match.Groups["minute"].Value);
    
    			Console.WriteLine(result);
    		}
    	}
    }
     
