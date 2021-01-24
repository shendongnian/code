    Console.WriteLine("Type in a number and then press enter:");
    double userInput;
    while (!double.TryParse(Console.ReadLine(), out userInput)
    {
        Console.WriteLine("Please Enter a valid numerical value!");
        Console.WriteLine("Please enter a valid number and then press enter:");
    }
    // After the above loop, the variable 'userInput' will contain the user's number
