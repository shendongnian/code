    void Main()
    {
    	Console.WriteLine(Calculator.Sum(2));    // Writes 4.
    	Console.WriteLine(Calculator.Sum());     // Writes 3.
    	Console.WriteLine(Calculator.Sum(b: 4)); // Writes 5.
    }
    
    class Calculator
    {
    	
    	public static int Sum(int a = 1, int b = 2)
    	{
    		return a + b;
    	}
    }
