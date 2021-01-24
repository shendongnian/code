	public static void Main()
	{
		string format = "0,000";
		decimal value = 5000m;
		Console.WriteLine(value.ToString(format));
		// 5,000.00
		value = 50000m;
		Console.WriteLine(value.ToString(format));
		// 50,000.00
		value = 5000.12m;
		Console.WriteLine(value.ToString(format));
		// 5,000.12
		value = 50000.12m;
		Console.WriteLine(value.ToString(format));
		// 50,000.12
		value = 50000000.1m;
		Console.WriteLine(value.ToString(format));
		// 50,000,000.10
	}
