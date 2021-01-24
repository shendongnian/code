    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public class Test
    	{
    		public string Name {get;set;}
    		public IEnumerable<Test> Children {get;set;}
    	}
    	
    	public static void Main()
    	{
    		var json = @"[
       {
          ""name"": ""AML Policy"",
          ""children"": [
             {
                ""name"": ""Test"",
                ""children"": [
                   {
                      ""name"": ""Test123"",
                      ""children"": []
                   }
                ]
             }
          ]
       },
       {
          ""name"": ""AML Policy2"",
          ""children"": []
       }
    ]";
    	
    		var tests = JsonConvert.DeserializeObject<IEnumerable<Test>>(json);
    		Console.WriteLine(tests.Last().Name);
    	}
    }
   
