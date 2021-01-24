static string GetUserInput(string term)
{
    string name;
    while (true)
    { 
        Console.Write($"Enter your {term}:");
        name = Console.ReadLine();
        bool isEmpty = string.IsNullOrEmpty(name);
        bool isIntString = name.All(char.IsDigit);
        bool containsInt = name.Any(char.IsDigit);
        if (isEmpty)
        {
            Console.WriteLine("Cannot be empty");
        }
        else if (isIntString)
        {
            Console.WriteLine("Cannot be made up of numbers");
        }
        else if (containsInt)
        {
            Console.WriteLine("Cannot contain numbers");
        }
        else
        {
           Console.WriteLine($"Your {term} filled");
           break;
        }
    }
    Console.WriteLine($"Your {term} is: {name}");
    return name;
}
