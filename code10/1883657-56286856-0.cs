c#
using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		var list = new List<string>();
		
		list.Add("test 1");
		list.Add("test 2");
		list.Add("test 3");
		list.Insert(2, null);
		
		var str = string.Join(",", list);
		
		Console.WriteLine(str); // test 1,test 2,,test 3
	}
}
