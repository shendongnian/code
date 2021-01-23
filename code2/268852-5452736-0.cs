    using System.Collections.Generic;
    using System;
    
    public class C {
    
    	public static void Main()
    	{
    		var dic = new Dictionary<int,int>();
    		dic[0] = 1;
    		dic[2] = 3;
    		dic[4] = 5;
    		
    		foreach (var i in Decompose(dic))
    			Console.WriteLine(i);
    			
    		Console.ReadLine();
    	}
    
    	public static IEnumerable<int> Decompose(IDictionary<int,int> dic)
    	{
    		foreach (var i in dic.Keys)
    		{
    			yield return i;
    			yield return dic[i];
    		}
    	}
    }
