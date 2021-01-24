    class Math
    {
    	private int n;
    	
    	private int k;
    	
    	public int DoingMath()
    	{
    
    
    		// Get the first input, keep the user in this loop until you get a vaild integer
    		while (true)
    		{
    			if (!int.TryParse(Console.ReadLine(), out n))
    			{
    				// not a valid integer 
    				Console.WriteLine("(n) Incorrect Input, please try again!");
    			}
    			else if (!(n >= 2 && n <= 1000000000))
    			{
    				// (n) should be between 2 and 1,000,000,000 
    				Console.WriteLine("(n) please choose integer between 2 and 1,000,000,000‬");
    			}
    			else
    			{
    				// it's a valid integer and between 2 and 1,000,000,000
    				break;
    			}
    
    
    		}
    
    		// Get the second input, keep the user in this loop until you get a vaild integer
    		while (true)
    		{
    			if (!int.TryParse(Console.ReadLine(), out k))
    			{
    				// not a valid integer 
    				Console.WriteLine("(k) Incorrect Input, please try again!");
    			}
    			else if (!(k >= 1 && k <= 50))
    			{
    				// (k) should be between 1 and 50 			
    				Console.WriteLine("(k) please choose integer between 1 and 50.");
    			}
    			else
    			{
    				// it's a valid integer and between 1 and 50 
    				break;
    			}
    		}
    
    		// now, do the subtraction logic 
    		for (int x = 0; x < k; x++)
    		{
    			if (n < 10) // if n has one digit, then decrease the number
    			{
    				n--;
    			}
    			else // if n has more than one digit 
    			{
    				var lastDigit = int.Parse(n.ToString().Substring(n.ToString().Length - 1));
    
    				if (lastDigit > 0)
    					n--;
    				else
    					n = n / 10;
    			}
    		}
    
    		return System.Math.Abs(n); // always returns positive number 
    	}
    }
