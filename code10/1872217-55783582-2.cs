    using System;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		string responseString = @"{ name: { first_name: 'Foo', last_name: 'Bar' }, emails: [ {value: 'foo@bar.com' } ] }";
    		JObject jo = JObject.Parse(responseString);
    		JObject obj = (jo["emails"] as JArray).FirstOrDefault(x => !string.IsNullOrEmpty(x.Value<string>("value"))) as JObject;
    		DaPOCO poco = new DaPOCO
    		{
    			FirstName = ((jo["name"] as JObject)["first_name"]).ToString(),
    			Email = obj["value"].ToString(),
    		};
    		
    		Console.WriteLine(poco.FirstName + "\t" + poco.Email);
    	}
    }
    
    public class DaPOCO
    {
      public string FirstName { get; set; }
      public string Email { get; set;} 
    }
