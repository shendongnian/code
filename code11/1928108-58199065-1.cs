using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
public class Program
{	
	public static void Main()
	{		
		var person = new{
			firstname = "Jim"
		};
		var city = new {
			name = "Mexico City"
		};
		var text = "Hello my name is {person.firstname} and my house is in {city.name}";
		
		foreach(var item in Program.ToDictionary(person, "person"))
			text = text.Replace(item.Key, item.Value);
		
		foreach(var item in Program.ToDictionary(city, "city"))
			text = text.Replace(item.Key, item.Value);
		
		Console.WriteLine(text);
	}
	private static Dictionary<string, string> ToDictionary(dynamic subj, string prefix){
		var json = JsonConvert.SerializeObject(subj);
		Dictionary<string, string>  deserialized = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
		var result = deserialized.ToDictionary(p => string.Format("{{{0}.{1}}}", prefix, p.Key), p=> p.Value);
		
		return result;
	}
}
The result will be:
> Hello my name is Jim and my house is in Mexico City
