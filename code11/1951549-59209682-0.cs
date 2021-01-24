C#
protected static int origRow;
protected static int origCol;
static void Main(string[] args)
{
    Console.SetWindowSize(120, 30);
    // Clear the screen, then save the top and left coordinates.
    Console.Clear();
    origRow = Console.CursorTop;
    origCol = Console.CursorLeft;
    int height = Console.WindowHeight;
    for (int i = 0; i < height; i++)
        WriteAt("|", 0, i);
    // this is to force to keep the application running. Now visual studio
    // will not put some extra text at the end of the screen
    Console.ReadLine();
}
// write a string as location x,y
public static void WriteAt(string s, int x, int y)
{
    try
    {
        Console.SetCursorPosition(origCol + x, origRow + y);
        Console.Write(s);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.Clear();
        Console.WriteLine(e.Message);
    }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.console.setcursorposition?view=netframework-4.8
