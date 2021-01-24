    using System;
    					
    public class Program
    {   	
    	private static char? randomLetterM = null;
    	
    	public static char RandomLetter
    	{
    		get
    		{
    			if (randomLetterM == null)
    			{
    				Random random = new Random();  
    				int index = random.Next(0, 25);  
    				randomLetterM = (char) (65 + index);
    			}
    			
    			return randomLetterM.Value;
    		}
    	}
    	
    	public static void Main()
    	{
            // Should print 3 same letters per run.
    		Console.WriteLine(RandomLetter);
    		Console.WriteLine(RandomLetter);
    		Console.WriteLine(RandomLetter);
    	}
    }
