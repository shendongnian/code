     private static int ReadInteger(String title = null) 
     {
         if (!string.IsNullOrWhiteSpace(title))
             Console.WriteLine(title);
         while (true) 
         {
             if (int.TryParse(Console.ReadLine(), out int result))
                 return result;
             Console.WriteLine("Sorry, the input is not a valid integer, try again");
          } 
     }
