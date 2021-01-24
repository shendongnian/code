    using System;
    using System.Net;
    
        public class Program
        {
        	public static void Main()
        	{
        		
        		string urlValue = "ITEM="+WebUtility.UrlEncode("A#1234") + "&CODE=0013&LOCATION=" + WebUtility.UrlEncode("LOCA#001");
        		Console.WriteLine(urlValue);
        		Console.WriteLine(WebUtility.UrlDecode(urlValue));
        		
        	}
        }
