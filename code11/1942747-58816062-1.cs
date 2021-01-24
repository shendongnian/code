    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
    	private static List<string> CompareLists2(List<string> list1, List<string> list2)
    	{
        	List<string> commonList = list1
               .Select(l1 => list2.FirstOrDefault(l2 => l2.Contains(l1)))
               .Where(x => x != null)
               .ToList();
    		return commonList;
	    }  
	
	
     	public static void Main()
    	{
    		var list2 = new List<string> { "/folder/foo", "/folder/bar", "/folder/baz" }; 
		    var list1 = new List<string> { "bar", "baz", "baz" };
		
     		var result = CompareLists2(list1,list2);
	    	// result is { "/folder/bar", "/folder/baz", "/folder/baz" }
        }
    }
