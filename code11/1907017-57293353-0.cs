    using System;
    using System.Text.RegularExpressions;					
    public class Program
    {
    	public static void Main()
    	{
    		  string str = "abcdef";
        string input = str.ToLower();
        int count = 0;
        char[] arrayInput = input.ToCharArray();
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        int[] amounts = new int[input.Length];
        
    	foreach (char letter in alphabet)
    	Console.Write(letter + ", ");
    	// observe the first letter here when you use regx.split
    	//, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z,	
    	
    	foreach (char inputWord in arrayInput)
    	Console.Write(inputWord + ", ");
    	// you get extra space in the start hence there is issue when you use regx.split
    	//, a, b, c, d, e, f,
    		
        foreach (var letter in alphabet)
        {
            for (int x = 0; x < input.Length; x++)
            {
                if (arrayInput[x] == letter)
                {
                   amounts[x] = amounts[x] + 1;
                }
            }
        }
        foreach (int amount in amounts)
        {
            Console.Write(amount + ", ");
        }
       
    	}
    }
  
