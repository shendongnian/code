    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var url1 = "C:/inetpub/wwwroot/XYZ/";
            var url2 = "/XYZ/Media/Default";
    		var f = url1.Split(new[]{'/'},StringSplitOptions.RemoveEmptyEntries);
    		var s = url2.Split(new[]{'/'},StringSplitOptions.RemoveEmptyEntries);
    		var fullurl = string.Join("/", f.Concat(s).Distinct());
    		Console.WriteLine(fullurl);
    	}
    }
