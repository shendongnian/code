        Console.WriteLine("Enter a two-digit number:");
        // Trim: let us be nice and tolerate leading and trailing spaces 
        // (esp. in case user put it with copy-pasting)
        entry = Console.ReadLine().Trim();
        // Just check the length
        if (entry.Length > 2)
        {
            Console.WriteLine("The number is longer than two-digit, please try again!");
        }
        // Check for length smaller than two-digit 
        else if (entry.Length < 2)
        {
            Console.WriteLine("The number is shorter than two-digit, please try again!");
        }
        // The length is correct, time to check the value
        else if (!Regex.IsMatch(entry, "^[0-9]{2}$")) // <- just a static method
        {
            Console.WriteLine("The input is not 2 digit number, please try again!")
        }
        // The entry is valid, let's ptint the result out
        else 
        {
           // You don't have to parse and do arithmetic 
           // if you want to convert char to corresponding digit: '7' -> 7
           int digit1 = entry[0] - '0';
           int digit2 = entry[1] - '0';
           // String interpolation is often more readable than formatting
           Console.WriteLine(
              $"The number has on the first place {digit1} and on the second place {digit2}");
        }
