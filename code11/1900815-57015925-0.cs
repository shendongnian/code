    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    
    public class Program
    {
    	
    	
    	
    	public const string Json = "{\"sets\": {\"set\": [{\"name\": \"Act 1:\",\"title\": [{\"name\":\"A\"},{\"name\": \"B\"},{\"name\": \"C\"},{\"name\": \"D\"}]},{\"name\": \"Act 2:\",\"title\": [{\"name\": \"E\"},{\"name\": \"F\"},{\"name\": \"G\"}]}]}}";
    
    	
    	public static void Main()
    	{
    		
    		Something something = JsonConvert.DeserializeObject<Something>(Json); 
    		
    		something.Titles = something.sets.set.SelectMany(c=> c.title).ToList();
    		
    		something.sets = null;
    		string JsonResult = JsonConvert.SerializeObject(something);
    		Console.WriteLine(JsonResult);
    	}
    }
    
    public class Something
    {
    	public Sets sets {get;set;}
    	
    
    	public List<Title> Titles {get;set;}
    }
    
    
    
    public class Sets
    {
    	public List<Set> set {get;set;}
    	
    
    }
    
    public class Set
    {
    	public string name {get;set;}
    	public List<Title> title {get;set;}
    }
    
    public class Title
    {
    	public string name {get;set;}
    }
