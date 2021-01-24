    public static string ShowSequence(int n)
    	{
    		if (n == 0)
    		{
    			return n + "=";
    		}
    
    		if (n < 0)
    		{
    			return n + "<";
    		}
    
    		int sumInt = 0;
    		string sum = "";
    		for (int i = 0; i <= n; i++)
    		{
    			if (i == n)
    			{
    				sum += i + " = ";
    			}
    			else
    			{
    				sum += i + "+";
    			}
    
    			sumInt += i;
    		}
    
    		sum += sumInt;
    		return sum;
    	}
