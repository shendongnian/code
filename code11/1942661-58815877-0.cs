static int CustomerMenuChoice()
{
    Console.WriteLine("Below is a list of actions that can be performed by customers: ");
    while(true)
    {
        Console.WriteLine("\nPress 1 to view movies available to rent.");
        Console.WriteLine("\nPress 2 to rent a movie.");
        Console.WriteLine("\nPress 3 to view a list of movies you currently have rented.");
        Console.WriteLine("\nPress 4 to return a movie rented.");
        Console.WriteLine("\nPress 5 to return to menu.");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        string customerChoice = Console.ReadLine();
        if (customerChoice == "1" || customerChoice == "2" || customerChoice == "3" || customerChoice == "4" || customerChoice == "5")
        {
            return int.Parse(customerChoice);
        }
        Console.WriteLine("Please enter a valid option: ");
    } 
}
Secondly I recommend looking a bit at the [switch-case][1] statement.
You could use it in several places of your code like so:
static void CustomerMenu()
{
    int customerChoice = 0;
    while (customerChoice != 5)
    {
        customerChoice = CustomerMenuChoice();
        switch (customerChoice)
        {
            case 1:
                Console.WriteLine("This shows movies available.\n");
                break;
            case 2:
                Console.WriteLine("This is to rent a movie.\n");
                break;
            case 3:
                Console.WriteLine("This is to show my rented movies.\n");
                break;
            case 4:
                Console.WriteLine("This is to show my rented movies.\n");
                break;
            case 5:
                Console.WriteLine("Returning to main menu, thank you.");
                break;
            default:
                // Option not in the list
                break;
        }
    }
}
One last thing, you might wanna look into using Console.ReadKey() instead of Console.ReadLine().
It will return without the user having to press enter and only takes one key at a time.
Personally I think it's perfect for these kinds of menus.
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
