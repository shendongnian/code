csharp
class Program
{
    public static void Warn(string msg)
    {
        // get current color selections
        var currentFGColor = Console.ForegroundColor;
        var currentBGColor = Console.BackgroundColor;
        // set warning colors
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine($"{msg}");
        // set the colors back to the current selections
        Console.ForegroundColor = currentFGColor;
        Console.BackgroundColor = currentBGColor;
    }
    static void Main(string[] args)
    {
        // get foreground input
        Console.Write("Foreground Color: ");
        string foregroundColorString = Convert.ToString(Console.ReadLine()).Trim();
        // get background input
        Console.Write("Background Color: ");
        string backgroundColorString = Convert.ToString(Console.ReadLine()).Trim();
        if (Enum.TryParse(foregroundColorString, ignoreCase: true, out ConsoleColor _foregroundColor))
        {
            Console.ForegroundColor = _foregroundColor;
        }
        else
        {
            Warn("- Invalid ForegroundColor option :(");
        }
        if (Enum.TryParse(backgroundColorString, ignoreCase: true, out ConsoleColor _backgroundColor))
        {
            Console.BackgroundColor = _backgroundColor;
        }
        else
        {
            Warn("- Invalid BackgroundColor option :(");
        }
        // output to the console using the requested colors (assuming they were valid)
        Console.WriteLine("Hello World!");
        Console.ResetColor();
        Console.WriteLine("\n\nPress any key to exit...");
        Console.ReadKey();
    }
}
