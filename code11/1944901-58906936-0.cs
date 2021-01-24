    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
      		int[] v = new int[] { 1, 2, 3 };
      		int[] w = new int[] { 4, 5, 6 };
    
    		Action<int> printInt = i => Console.WriteLine(i);
      		MixedSum(v, w, printInt);
    	}
    	
    	static int MixedSum(int[] v, int[] w, Action<int> printDelegate)
    	{
    	  int rx = 0;
    	  for (int c = 0; c < v.Length; c++)
    	  {
    		for (int d = 0; d < w.Length; d++)
    		{
    		  rx = v[c] + w[d];
    		  printDelegate(rx);
    		 }
    	   }
    	  return 0;
    	}	
    }
