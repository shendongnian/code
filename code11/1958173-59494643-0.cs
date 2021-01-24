	public static void Main()
	{
		double num1 = 0;
		if(num1.GetType() == typeof(double)) 
		{
			Console.WriteLine("num1 is a double");
		}
		else
		{
			Console.WriteLine("num1 is not a double, it is a " + num1.GetType().FullName);	
		}
        
		int num2 = 0;
		if(num2.GetType() == typeof(double)) 
		{
			Console.WriteLine("num2 is a double");
		}
		else
		{
			Console.WriteLine("num2 is not a double, it is a " + num2.GetType().FullName);	
		}
	}
