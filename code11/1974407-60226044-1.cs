    using System.Linq;
    ...
    int[] digits = null;
    while (true) {
      Console.WriteLine("enter a number:");
      // string : let's solve for arbitrary long numbers (no necessary int)
      string number = Console.ReadLine().Trim();
      if (string.IsNullOrEmpty(number)) 
        Console.WriteLine("Empty string is not enough");
      else if (number.All(c => c >= '0' && c <= '9')) {
         // This code preserves leading zeroes
         digits = number.Select(c => c - '0').ToArray();
         // This code removes leading zeroes
         //digits = number
         //  .SkipWhile(c => c == '0')
         //  .Select(c => c - '0')
         //  .DefaultIfEmpty()
         //  .ToArray();
        break;
      } 
      else
        Console.Write("Not a valid integer value. Please, try again."); 
    }
