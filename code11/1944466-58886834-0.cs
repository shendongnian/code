    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		int[] array = new int[]{1, 2, 3, 4, 5, 6, 7};
    		int start = 0;
    		int end = array.Length - 1;
    		while (start < end)
    		{
    			int temp = array[start];
    			array[start] = array[end];
    			array[end] = temp;
    			start++;
    			end--;
    		}
    
    		Console.WriteLine("Result: {0}", String.Join("", array));
    	}
    } 
