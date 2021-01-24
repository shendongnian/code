    void Main()
    {
    	    int num1 = 0;
            int num2 = 0;
            Console.WriteLine("Enter a number:");
            while (!int.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Error");
            }
            Console.WriteLine(num1);
            Console.WriteLine("Enter a number:");
            while (!int.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Error");
            }
            Console.WriteLine(num1);
            Console.WriteLine("Result = {0}", Count(num1, num2));
    }
