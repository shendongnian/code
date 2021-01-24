    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using static System.Console;
    
    public static class MyParser
    {
    	public static void ParseObj<T>(T data)
    	{
    		foreach (var prop in data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
    		{
    			if(prop.PropertyType.IsArray) WriteLine($"{prop.Name}:array");
    			else if(prop.PropertyType == (typeof(string))) WriteLine($"{prop.Name}:string");
    			else if(prop.PropertyType.IsValueType) WriteLine($"{prop.Name}:value type");
    			else if(typeof(IEnumerable).IsAssignableFrom(prop.PropertyType)) WriteLine($"{prop.Name}:IEnumerable");
    			else if(prop.PropertyType.IsEnum) WriteLine($"{prop.Name}:enum");
    			else if(prop.PropertyType.IsClass) WriteLine($"{prop.Name}:class");
    			else WriteLine($"{prop.Name}:something else");
    		}
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		MyParser.ParseObj(new
    		{
    			Str = "abc"
    			, Num = 543
    			, Arr = new[]{1, 2, 3}
    			, Chars = new char[]{'x', 'y', 'z'}
    			, SomeList = new List<string>(){"a","b","c"}
    		});
    	}
    }
