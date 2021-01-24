    public static void Main(string[] args)
    {
        Console.WriteLine("What is my Integer?");
        if (int.TryParse(Console.ReadLine(), out int myInt))
        {
            Console.WriteLine("What is your integer?");
            if (int.TryParse(Console.ReadLine(), out int yourInt))
            {
                int total = myInt + yourInt;
                Console.WriteLine("Our integer is " + total);
                return;
            }
        }
        Console.WriteLine("Invalid input.");
    }
