    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Architecture: ");
    Console.ForegroundColor = ConsoleColor.Green;
    bool is64 = Environment.Is64BitOperatingSystem;
    if (is64) { Console.WriteLine("64 bit"); }
    else { Console.WriteLine("32 bit"); }
