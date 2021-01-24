    using System.Linq;
    using System.Collections.Generic;
    static void Test()
    {
      int capacity = 20;
      List<int> numbers = new List<int>(capacity);
      Console.WriteLine($"Enter up to {capacity} numbers (0 or not an integer to stop): ");
      int value = 0;
      do
      {
        int.TryParse(Console.ReadLine(), out value);
        if ( value != 0 )
          numbers.Add(value);
      }
      while ( numbers.Count < capacity && value != 0 );
      if ( numbers.Count > 0 )
      {
        Console.WriteLine();
        Console.WriteLine("Enter a number to search occurences: ");
        int.TryParse(Console.ReadLine(), out value);
        if ( value > 0 )
        {
          Console.WriteLine();
          Console.WriteLine("The number {0} shows up {1} times",
                            value, 
                            numbers.Count(n => n == value));
        }
      }
    }
