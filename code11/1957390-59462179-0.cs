    using System;
    using System.Net;
    using System.Text.Json;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		const string jsonHtmlEscaped = @"&quot;[[[{\&quot;lat\&quot;:35.71467081484196,\&quot;lng\&quot;:51.41189575195313},{\&quot;lat\&quot;:35.70254403049943,\&quot;lng\&quot;:51.45472526550293},{\&quot;lat\&quot;:35.69292492425683,\&quot;lng\&quot;:51.402111053466804}]]]&quot;";
    		Console.WriteLine("Raw string:");
    		Console.WriteLine(jsonHtmlEscaped);
    		Console.WriteLine();
    		
    		var jsonEscaped = WebUtility.HtmlDecode(jsonHtmlEscaped);
    		Console.WriteLine("After Html Decode:");
    		Console.WriteLine(jsonEscaped);
    		Console.WriteLine();
    		
    		var json = JsonSerializer.Deserialize<string>(jsonEscaped);
    		Console.WriteLine("After unescape JSON:");
    		Console.WriteLine(json);
    		Console.WriteLine();
    		
    		var latAndLongRaw = JsonSerializer.Deserialize<System.Text.Json.JsonElement[][][]>(json);
    		var latAndLong = latAndLongRaw
    			.SelectMany(a => a)
    			.SelectMany(a => a)
    			.Select(a => (Latitude: a.GetProperty("lat").GetDecimal(), Longitude: a.GetProperty("lng").GetDecimal()))
    			.ToList();
    		
    		Console.WriteLine("After parsing:");
    		foreach(var (latitude, longitude) in latAndLong)
    		{
    			Console.WriteLine($"Lat: {latitude}, Lon: {longitude}");
    		}
    	}
    }
