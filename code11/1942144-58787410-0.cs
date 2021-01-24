    static void Main()
    {
        for (int x = 0; x < 100; x++)
        {
            if (x % 10 == 0)
                Console.SetCursorPosition(0, 0);
            else
                Console.SetCursorPosition(0, x % 10);
            Console.WriteLine(x);
            WriteStatusText("Printing line " + x);
            // Remove this comment to see it slowly 
            // Console.ReadLine();
        }
        Console.ReadLine();
    }
    static void WriteStatusText(string msg)
    {
        Console.SetCursorPosition(0, 10);
        Console.WriteLine(msg);
    }
