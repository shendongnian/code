using System;
using Newtonsoft.Json;
public class Program
{
	public static void Main()
	{
        var message = "Hello, World!";
		string json = JsonConvert.SerializeObject(new 
        {
			id = 123,
			message = message
		});
		
		Console.WriteLine(json);
        // {"id":123,"message":"Hello, World!"}
	}		
}
DEMO: https://dotnetfiddle.net/FPFrng
