    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		// a custom class
    		public class MyPerson
    		{
    			public string FN { get; set; }
    			public string LN { get; set; }
    		}
    		static void Main(string[] args)
    		{
    			// your prebuilt dictionary of Types to Lambda expressions to get a string
    			Dictionary<Type, Func<object, String>> MyToStringLookup = new Dictionary<Type, Func<object, string>>()
    			{
    				
    				{typeof(String), new Func<Object, String>( obj => obj.ToString() )},
    				{typeof(DateTime), new Func<Object, String>( obj => ((DateTime)obj).ToString("d") )},
    				{typeof(MyPerson), new Func<Object, String>( obj => (obj as MyPerson).LN )},
    			};
    			// your list of objects
    			List<Object> MyObjects = new List<Object>()
    			{
    				"abc123",
    				DateTime.Now,
    				new MyPerson(){ FN = "Bob", LN = "Smith"}
    			};
    			// how you traverse the list of objects and run the custom ToString
    			foreach (var obj in MyObjects)
    				if (MyToStringLookup.ContainsKey(obj.GetType()))
    					System.Console.WriteLine(MyToStringLookup[obj.GetType()](obj));
    				else // default if the object doesnt exist in your dictionary
    					System.Console.WriteLine(obj.ToString());
    		}
    	}
    }
