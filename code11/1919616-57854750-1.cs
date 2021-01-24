using System;
using System.IO;
using Newtonsoft.Json;
					
public class Program
{
	public static void Main()
	{
		var objSource= new RootObject{
			Data= new Data{
				id="123456",
				data="FooBar"
			}
		};		
			
		var serializer = new JsonSerializer();
		var stringWriter = new StringWriter();
		var writer = new JsonTextWriter(stringWriter);
		writer.QuoteName = false;
		writer.QuoteChar = '\'';
		serializer.Serialize(writer, objSource);		
		
		var input= stringWriter.ToString();
		Console.WriteLine(input);
		
		JsonTextReader reader = new JsonTextReader(new StringReader(input));
		var result = serializer.Deserialize<RootObject>(reader);
		
		result.Dump();
	}
	
	public class Data
	{
		public string id { get; set; }
		public string data { get; set; }
	}
	public class RootObject
	{
		public Data Data { get; set; }
	}
}
[live demo](https://dotnetfiddle.net/m3T1Ye)
<hr>
Disclaimer: As Jodrell noticed it return a "RootObject".
The writer will return `{Data:{id:'123456',data:'FooBar'}}`   
instead of `Data:{id:'123456',data:'FooBar'}` Notice the extra `{}` around the string.  
The string manipulation needed to get from one too the other is minor enought. 
