    int suppliedInt;
    
    Console.WriteLine("Please enter a number greater than zero");
    Int32.TryParse(Console.ReadLine(), out suppliedInt);
    
    if (suppliedInt > 0) {
        Console.WriteLine("You entered: " + suppliedInt);
    }
    else {
        Console.WriteLine("You entered an invalid number. Press any key to exit");
    }
                
    Console.ReadLine();
