    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<int> intList = new List<int>{1,2,3,4,1};
    		System.Console.WriteLine("Elements: \r\n");
    		for(int index =0; index < intList.Count-1; index++)
    		{
    			System.Console.Write(intList[index].ToString());
    			System.Console.Write(", ");
    		}
    		if(intList.Count > 1)
			    System.Console.Write("and ");
		    if(intList.Count > 0)
			    System.Console.Write(intList[intList.Count-1]);		
		    else
			    System.Console.Write("<<Empty List>>");
    	}
    }
