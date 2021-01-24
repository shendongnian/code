    void GetConsoleUserInput()
    {
      Console.WriteLine("Enter something:");
      var result = new List<char>();
      int index = 0;
      while ( true )
      {
        var input = Console.ReadKey(true);
        if ( input.Modifiers.HasFlag(ConsoleModifiers.Control) 
          && input.Key.HasFlag(ConsoleKey.Enter) )
          break;
        if ( char.IsLetterOrDigit(input.KeyChar) )
        {
          if (index == result.Count)
            result.Insert(index++, input.KeyChar);
          else
            result[index] = input.KeyChar;
          Console.Write(input.KeyChar);
        }
        else
        if ( input.Key == ConsoleKey.LeftArrow && index > 0 )
        {
          index--;
          Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
        // And so on
      }
      Console.WriteLine();
      Console.WriteLine("You entered: ");
      Console.WriteLine(String.Concat(result));
      Console.WriteLine();
      Console.ReadKey();
    }
