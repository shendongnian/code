    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string src = "";
    		Regex Pattern = new Regex("<img\\s+src\\s*=\\s*\"(.*?)\"", RegexOptions.Multiline);
    		string str = "<div> <img src=\"https://i.testimg.com/images/g/test/s-l400.jpg\" style=\"width: 100%;\"> <div>Test</div> </div>";
    		var res = Pattern.Match(str);
    		if (res.Success)
    		{
    			src = res.Groups[1].Value;			
    		}
    		Console.WriteLine(src);
    	}
    }
