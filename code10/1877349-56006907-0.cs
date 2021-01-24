    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number less than 20: ");
        string userInput = Console.ReadLine();
        
        if(!int.TryParse(userInput, out int number))
            Console.WriteLine("Please enter a valid number between 0 and 20");
        else if(number > 0 && number < 20)
        {
            int result = 20 - number;
            Console.WriteLine($"Difference of {result} is needed to get to 20.");
        }
        else
            Console.WriteLine("Please enter a number greater than 0 and smaller than 20");
    }
