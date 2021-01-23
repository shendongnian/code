    using System;
    using System.IO;
    
    class Steve {
    
      public static void Main() {
        string[] lines = File.ReadAllLines("Steve.txt");
        while (true) {
          int line;
          if (Int32.TryParse(Console.ReadLine(), out line)) {
            if (line >= 0 && line < lines.Length) {
              Console.WriteLine(lines[chooseLine]);
            } else {
              Console.WriteLine("Error! Array index out of bounds");
            }
          } else {
            Console.WriteLine("Error! Not a number");
          }
        }
      }
    }
