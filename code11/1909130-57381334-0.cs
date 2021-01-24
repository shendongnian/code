    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public static void Main()
    	{
    		var theReturn = new List<MyObject>{
                new MyObject{ID = 1},
                new MyObject{ID = 2},
                new MyObject{ID = 3}
            };
    		Console.WriteLine(JsonConvert.SerializeObject(theReturn));
    	}
    
    	public class MyObject
    	{
    		public int ID
    		{
    			get;
    			set;
    		}
    	}
    }
