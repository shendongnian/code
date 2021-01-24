    private static void Main(string[] args)
    {
        int celsius;
        Console.WriteLine("Hello! Welcome to the sauna!\n");
        do
        {
            // Use a loop with TryParse to validate user input; as long as
            // int.TryParse returns false, we continue to ask for valid input
            int fahrenheit;
            do
            {
                Console.Write("Please enter your desired degrees in Fahrenheit: ");
            } while (!int.TryParse(Console.ReadLine(), out fahrenheit));
            celsius = FahrenheitToCelsius(fahrenheit);
            // Rest of loop code omitted...
        } while (celsius < 73 || 77 < celsius);
        Console.ReadLine();
    }
