    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var jsonString = @"{'Units':'mm','test':[{'Val':true,'Val1':false}], 'test1':[{'Val2':'red','Val3':'5'}]}";
    		var data= JsonConvert.DeserializeObject<RootObject>(jsonString);
    		Console.WriteLine(data.Units);
    		
    		foreach(var values in data.test)
    		{
    			Console.WriteLine(values.Val);	
    	    	Console.WriteLine(values.Val1);
    		}
    		
    		foreach(var values1 in data.test1)
    		{
    			Console.WriteLine(values1.Val2);	
    	    	Console.WriteLine(values1.Val3);
    		}		
    	}
    }
    
    public class Test
    {
        public bool Val { get; set; }
        public bool Val1 { get; set; }
    }
    
    public class Test1
    {
        public string Val2 { get; set; }
        public string Val3 { get; set; }
    }
    
    public class RootObject
    {
        public string Units { get; set; }
        public List<Test> test { get; set; }
        public List<Test1> test1 { get; set; }
    }
