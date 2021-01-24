    Console.Write("\tBitte geben Sie ihre Rechenoperation ein: ");
    string r_operation = Console.ReadLine();
    int result = 0;
    while (!int.TryParse(r_operation, out result))
    {
        Console.WriteLine("\tUngültige Eingabe. Bitte geben Sie nur Zahlen ein!");
        Console.Write("\tBitte geben Sie ihre Rechenoperation ein: ");
        r_operation = Console.ReadLine();
    }
    // When we exit the while loop, we know that 'r_operation' is a number, 
    // and it's value is stored as an integer in 'result'
