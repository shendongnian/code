    if (choose == 5)
    {
        
        //change this
        Console.WriteLine("Money in wallet: ",total,"$");
        //to this
        //Here are two alternatives. Choose one
        Console.WriteLine("Money in wallet: {0}$", total); // Composite formatting
        Console.WriteLine($"Money in wallet: {total}$"); // String interpolation
    }
