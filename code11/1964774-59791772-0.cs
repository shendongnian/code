    using Newtonsoft.Json;
    using System;
    using Microsoft;
    
    public class Program
    {
    	public static void Main()
    	{
    		Service c = new Service();
            c.description = "desc";
            c.service = "serv";
            string json = JsonConvert.SerializeObject(c, Formatting.Indented);
    		Console.WriteLine(json);
    
    	}
    	
    	public class Service
    	{
       	 	public Service() { }
        	public string service;
        	public string description;
    	}
    
            
    }
