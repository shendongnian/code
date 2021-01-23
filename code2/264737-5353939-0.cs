    while (processing input)
    {
      char input = Console.ReadKey (true); // true stops echoing
      
      if (char.IsDigit (input))
      {
         Console.Write (input);
         // and any processing you may want to do with the input
      }
    }
