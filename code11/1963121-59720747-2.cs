    public static void Main()
	{
		Console.WriteLine("What is my Integer?");
		int myInt = int.Parse(Console.ReadLine());
		Console.WriteLine("What is your integer?");
		int yourInt = int.Parse(Console.ReadLine());
		int total = myInt + yourInt;
		Console.WriteLine("Our integer is " + total);
	}
