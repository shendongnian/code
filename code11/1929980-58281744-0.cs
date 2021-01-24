       while (true) {
         // 0 is not a good choice; let it be Q (Quit) instead
         Console.WriteLine("Give a number or Q to stop : ");
         // Trim: let's be nice and tolerate trailing/leading spaces 
         string input = Console.ReadLine().Trim(); 
         // Let's accept Q, q, quit, etc.
         if (input.StartsWith("Q", StringComparison.OrdinalIgnoreCase))
           break;           
         if (int.TryParse(input, out int value)) 
           number.Add(value);  
         else
           Console.WriteLine("Sorry, invalid input");
       }
