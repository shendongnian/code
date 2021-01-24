    public static double ReadDouble(string title) {
      Console.WriteLine(title);
    
      while (true) {
        if (double.TryParse(Console.ReadLine(), out double result))
          return result;
    
        Console.WriteLine("Sorry, invalid syntax. Please, provide floating point value.");
      }
    }
