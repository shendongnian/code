    public static void FindIndexRec(int input, int power, ICollection<int> numbers)
    {
    	if (input == 0)
    	{
    		return;
    	}
    	var digit = input % 2;
    	if (digit == 1)
    	{
    		numbers.Add((int)Math.Pow(2, power));
    	}
    	FindIndexRec(input / 2, ++power, numbers);
    }
