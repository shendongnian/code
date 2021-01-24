    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Spelling check is set to " + document.SpellingChecked);
    Console.WriteLine(fileName);
    if (!document.SpellingChecked)
    {
        document.SpellingChecked = true;
        Console.WriteLine("Spelling check has now been changed to " + document.SpellingChecked);
    }
