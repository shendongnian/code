      private static float ReadSingle(string title = null) {      
        while (true) {
          if (!string.IsNullOrWhiteSpace(title))
            Console.WriteLine(title);
          if (float.TryParse(Console.ReadLine(), out float result))
            return result;
          Console.WriteLine("Invalid format, please try again.");  
        }
      }
