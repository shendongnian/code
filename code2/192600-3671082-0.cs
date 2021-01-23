    public void bet()
    {
        int betAmount;
        Console.WriteLine("How much would you like to bet?");
        while(!int.TryParse(Console.ReadLine(), out betAmount))
        {
            Console.WriteLine("Please enter a valid number.");
            Console.WriteLine();
            Console.WriteLine("How much would you like to bet?");
        }
        Console.WriteLine(_chips - betAmount);
    } 
