    Console.WriteLine("Press Escape (Esc) to quit the program.");
    cki = Console.ReadKey();
    while(cki.Key != ConsoleKey.Escape) {
        stuffs.Add(cki.Key.ToString());
        cki = Console.ReadKey();
        Console.WriteLine();
    }
