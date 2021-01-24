    // Add any valid values to this array
    var validValues = new[] {"Red", "Blue", "Green"};
    var prompt = $"Select Colour ({string.Join(" / ", validValues)}): ";
    Console.Write(prompt);
    string userInput = Console.ReadLine();
    while (!validValues.Contains(userInput, StringComparer.OrdinalIgnoreCase))
    {
        Console.WriteLine($"Sorry, '{userInput}' is not a valid value.");
        Console.Write(prompt);
        userInput = Console.ReadLine();
    }
    Console.WriteLine("Alright " + userInput + ", good. ");
