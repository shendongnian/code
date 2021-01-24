    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		int[] numbers = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17};
    		shuffle(numbers);
    		Console.WriteLine(String.Join(", ", numbers));
    	}
    
    	private static void shuffle(int[] numbers)
    	{
    		Random r = new Random((int)DateTime.Now.Ticks);
    		for (int i = 0; i < numbers.Length; i++)
    		{
    			int temp = numbers[i];
    			int index = r.Next(numbers.Length);
    			numbers[i] = numbers[index];
    			numbers[index] = temp;
    		}
    	}
    }
