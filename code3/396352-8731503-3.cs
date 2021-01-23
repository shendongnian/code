    public static string GenerateNewCode(int CodeLength)
    {
        Random random = new Random();
        StringBuilder output = new StringBuilder();
        do
    	{	
    		for (int i = 0; i < CodeLength; i++)
    		{
    			output.Append(random.Next(0, 10));
    		}
    	}
    	while (!ConsumerCode.isUnique(output.ToString()));
    	return output.ToString();
    }
