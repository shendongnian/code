    Console.WriteLine("Select Colour (Red / Blue / Green): ");
    string colSel = Console.ReadLine().ToLower();
    
    // strings are now 'lowered'.
    // also changed it so that all the variables look to colSel instead
    while (colSel != "red" && colSel != "blue" && colSel != "green")
    {
    
       Console.WriteLine("Sorry, I didn't catch that...");
       Console.Write("Select Colour (Red / Blue / Green): ");
       colSel = Console.ReadLine().ToLower();
    }
    
    // Use string interpolation instead of concatenation
    Console.WriteLine($"Alright {colSel}, good. ");
