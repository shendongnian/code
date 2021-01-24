     private static int ReadInteger(string title) {
       while (true) {
         if (!string.IsNullOrWhiteSpace(title))
           Console.WriteLine(title);
         if (int.TryParse(Console.ReadLine(), out int result))
           return result;
         Console.WriteLine("Incorrect syntax, please, try again.");
       }
     }
