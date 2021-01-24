    int x;
    
    Console.WriteLine("Enter the first number: ");
    while (!Int32.TryParse(Console.ReadLine(), out x))
       Console.WriteLine("Invalid input! Try again");
    
    Console.WriteLine($"You had one job and it was a success : {x}");
