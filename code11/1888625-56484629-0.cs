    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    					
    public class Program
    {
    	public class MyType 
    	{
    		public string Name {get;set;}
    		public MyType(){}
    		public MyType(string name) {
    		  this.Name = name;
    		}
    		
    		public override string ToString()
    		{
    			return this.Name ?? "empty";
    		}
    	}
    	
    	public static void Main()
    	{
    		List<MyType> list = new List<MyType>();
    		list.Add(new MyType("One"));
    		list.Add(new MyType("Two"));
    		DoSomethingWithUnknown(list);
    	}
    	
    	public static void DoSomethingWithUnknown(object argList)
    	{
    		var list = (IList)argList;
    		foreach(var item in list)
    		{
    			Console.WriteLine("As object: " + item);
    			dynamic itm = item;
    			Console.WriteLine("As dynamic: " + itm.Name);
    		}
    	}
    }
