      int x;
      // read input until user inputs a digit instead of string or etc.
      do
      {
        Console.WriteLine("Input a number between 1-100");
      }
      while (!Int32.TryParse(Console.ReadLine(), out x));
    
      // if input isn't between 1 and 101, close program.
      if (x < 1 || x > 100)
        return;
      // else count from given number to 101
      for(int i = x; i < 101; ++i)
      {
        Console.WriteLine(i);
      }
