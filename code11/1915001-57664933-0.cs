    static void DrawRectangle(Rectangle rect, ConsoleColor color = ConsoleColor.Blue, 
        char fill = '█')
    {
        var foreColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.SetCursorPosition(rect.Left, rect.Top);
        for (int i = 0; i < rect.Height; i++)
        {
            Console.Write(new string(fill, rect.Width));
            Console.SetCursorPosition(rect.Left, Console.CursorTop + 1);
        }
        Console.ForegroundColor = foreColor;
    }     
    private static void Main()
    {
        Console.CursorVisible = false;
        // Draw a rectangle
        var rect = new Rectangle(10, 10, 10, 5);
        DrawRectangle(rect);
        // Move the rectangle when the user presses an arrow key
        while (true)
        {
            // Wait for a key press
            while (!Console.KeyAvailable) ;
            // "Erase" the current rectangle
            DrawRectangle(rect, Console.BackgroundColor);
            // Set the location for the new rectangle based on the key that was pressed
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                {
                    var location = new Point(rect.X, rect.Y - 1);
                    rect = new Rectangle(location, rect.Size);
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    var location = new Point(rect.X, rect.Y + 1);
                    rect = new Rectangle(location, rect.Size);
                    break;
                }
                case ConsoleKey.LeftArrow:
                {
                    var location = new Point(rect.X - 1, rect.Y);
                    rect = new Rectangle(location, rect.Size);
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    var location = new Point(rect.X + 1, rect.Y);
                    rect = new Rectangle(location, rect.Size);
                    break;
                }
            }
            // Draw the new rectangle
            DrawRectangle(rect);
        }
        GetKeyFromUser("\n\nDone! Press any key to exit...");
    }
