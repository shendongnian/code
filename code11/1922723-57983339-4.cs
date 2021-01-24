    // Add any valid values to this array
    var validValues = new[] {"Red", "Blue", "Green"};
    var promptString = $"Select Colour ({string.Join(" / ", validValues)}): ";
    Console.Write(promptString);
    string colSel = Console.ReadLine();
    while (!validValues.Contains(colSel, StringComparer.OrdinalIgnoreCase))
    {
        Console.WriteLine("Sorry, I didn't catch that...");
        Console.Write(promptString);
        colSel = Console.ReadLine();
    }
    Console.WriteLine("Alright " + colSel + ", good. ");
