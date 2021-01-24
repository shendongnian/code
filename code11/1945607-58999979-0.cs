using System; 
using System.Collections.Generic;
public class TEST 
{ 
   static public void Main(string[] args)
    {
        var test =  new Dictionary<int, string>();
		test.Add(1,"One");
        Console.WriteLine(test); //outputs test
        Console.WriteLine(TEST.TestMethod(test));  //outputs slab
    }
    static public string TestMethod(dynamic obj)
    {
		foreach (KeyValuePair<int, string> item in obj)
        {
            Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
		    return item.Value;
        }
	    return "";   
    }
} 
