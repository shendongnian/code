    static void Main(string[] args) {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Clear();
      int left = Console.CursorLeft;
      int top = Console.CursorTop;
      Console.WriteLine("Remove me!");      // <- We'll remove this
      Console.WriteLine("Hello С#!");       // <- But we'll spare this
      Console.ReadLine();
      int currentLeft = Console.CursorLeft;
      int currentTop = Console.CursorTop;
      Console.CursorLeft = left;
      Console.CursorTop = top;
      Console.Write("Sorry, I mean \"Hello Console!\"");
      Console.CursorLeft = currentLeft;
      Console.CursorTop = currentTop;
      Console.Write("That's nice now!");
      Console.ReadLine();
    }
