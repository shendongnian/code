    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		Dictionary<string,int> origDict = new Dictionary<string,int>{{"tttt",1},{"fttt",1},{"fftt",2}};
    		
    		var vals = new int[origDict.Count];
    		origDict.Values.CopyTo(vals,0);
    		
    		var keys = new string[origDict.Count];
    		origDict.Keys.CopyTo(keys,0);
    		
    		Dictionary<int,List<string>> newDict = new Dictionary<int,List<string>>();
    		for(int i = 0; i < vals.Length; i++){
    			int val = vals[i];
    			if(newDict.ContainsKey(val)){
    				newDict[val].Add(keys[i]);
    			}else{
    				newDict[val] = new List<string>();
    				newDict[val].Add(keys[i]);
    			}
    		}
    		foreach(var key in newDict.Keys){
    			Console.WriteLine(key);
    			foreach(var val in newDict[key]){
    				Console.WriteLine(val);
    			}
    		}
    	}
    }
