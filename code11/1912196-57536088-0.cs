    using System;
    using Newtonsoft.Json;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var jsonString = "{'id': 1, 'name': Bob, 'age': 25},{'id': 2, 'name': Mark, 'age': 32},{'id': 3, 'name': Simon, 'age': 16}";
    		jsonString = jsonString.Replace("\'", "");
    		jsonString = Regex.Replace(jsonString, @"\w+", @"""$0""");
    		jsonString = "[" + jsonString + "]";
    		
    		var data = JsonConvert.DeserializeObject<Data[]>(jsonString);
    	}
    }
    
    public class Data
    {
    	public int id {get;set;}
    	public string name {get;set;}
    	public int age {get;set;}
    }
