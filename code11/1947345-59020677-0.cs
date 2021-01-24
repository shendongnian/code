    using System;
    using System.Linq;
	
    public class Program
    {
    	public static void Main()
	    {
		    int [] myArray = {1,2,3};
    		int [] myArray2 = {1,2,4};
		
    		bool result = myArray.SequenceEqual(myArray2);
    	}
    }
