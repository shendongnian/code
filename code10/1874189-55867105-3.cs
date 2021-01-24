    public static double Coefficient() {
      while (true) {
        string input = Console.ReadLine();
        string[] items = input.Split('^');
        if (items.Length == 1) {
          if (double.TryParse(items[0], out double A))
            return A; // One valid value 
        }
        else if (items.Length == 2) {
          if (double.TryParse(items[0], out double A) && 
              double.TryParse(items[1], out double B))
            return Math.Pow(A, B); // Two valid values
        } 
        // Neither one valid value, nor two valid values pattern 
        Console.WriteLine("Please follow the specified input form (a^b)."); 
        // No need in "Console.ReadKey();" - the routine will stop on Console.ReadLine()
      }          
    } 
