    using System;
    using Newtonsoft.Json.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
            string json = @"
                {
                  ""CPU"": ""Intel"",
                  ""Integrated Graphics"": true,
                  ""USB Ports"": 6,
                  ""OS Version"": 7.1,
                  ""Drives"": [
                    ""DVD read/writer"",
                    ""500 gigabyte hard drive""
                  ],
    			  ""ExtraData"" : {""Type"": ""Mighty""}
                }";
    		
    		JObject o = JObject.Parse(json);
    
    		Console.WriteLine(o["CPU"]);
    		Console.WriteLine();
    		Console.WriteLine(o["Drives"]);
    		Console.WriteLine();
    		Console.WriteLine(o["ExtraData"]["Type"]);
	    	
    		Console.ReadLine();
    	}
    }
 
