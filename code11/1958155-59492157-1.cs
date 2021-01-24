        // This needs to be written just one time
        Console.Write("distance from target : ");
        // Now get the current cursor position after the write above
        int posX = Console.CursorLeft;
        int posY = Console.CursorTop;
      
        for (int i = distance; i > 0; i = i - 3)
        {
            // Position the cursor where needed
            Console.SetCursorPosition(posX, posY);
            // Replace the previous write with a number aligned on the left on 4 spaces
            Console.Write($"{i,-4:D}");
            Thread.Sleep(30);
        }
        // Do not forget to jump to the next line
        Console.WriteLine("\r\nBloooW!");
