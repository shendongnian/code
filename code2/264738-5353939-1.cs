    while (processing input)
    {
      ConsoleKeyInfo input_info = Console.ReadKey (true); // true stops echoing
      char input = input_info.KeyChar;
      
      if (char.IsDigit (input))
      {
         Console.Write (input);
         // and any processing you may want to do with the input
      }
    }
