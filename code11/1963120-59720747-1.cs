    public static void Main()
	{
		Console.WriteLine("What is my Integer?");
		int myInt = int.Parse(Console.ReadLine());
		Console.WriteLine("What is your integer?");
		int yourInt = int.Parse(Console.ReadLine());
        // The addition is performed after the assignments.
		int total = myInt + yourInt;
		Console.WriteLine("Our integer is " + total);
	}
