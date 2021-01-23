	static void Main(string[] args)
	{      
		try
		{
			Method();
		}
		catch (Exception)
		{
			Console.WriteLine("caught in main");
		}
		Console.ReadKey();
	}
	public static void Method()
	{
		try
		{
			throw new Exception("Exception");
		}
		catch (Exception)
		{
			Console.WriteLine("Catch");
			throw;
		}
		finally
		{
			Console.WriteLine("Finally");
		}
	}
