    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
                string url = "https://dotnetfiddle.net:333/?a=1";
                UriBuilder uri = new UriBuilder(url);
                Console.WriteLine(uri.Scheme + Uri.SchemeDelimiter + uri.Host + (url.Contains(uri.Port.ToString()) ? ":" + uri.Port : "") + (uri.Path.Length > 1 ? uri.Path : uri.Path.TrimStart('/')) + uri.Query);
    	}
    }
