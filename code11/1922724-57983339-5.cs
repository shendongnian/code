    Console.Write("Select Colour (Red / Blue / Green): ");
    string colSel = Console.ReadLine().ToLower();
    while (colSel != "red" && colSel != "blue" && colSel != "green")
    {
        Console.WriteLine("Sorry, I didn't catch that...");
        Console.Write("Select Colour (Red / Blue / Green): ");
        colSel = Console.ReadLine().ToLower();
    }
    Console.WriteLine("Alright " + colSel + ", good. ");
