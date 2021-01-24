    Console.Write("Enter a made up password: ");
    string madeUpPwd = Console.ReadLine();
    // Get the distinct characters that aren't Letters or Digits
    IEnumerable<char> symbols = madeUpPwd
        .Where(c => !char.IsLetter(c) && !char.IsDigit(c))
        .Distinct();
    // Output them to the console (separated by commas and wrapped in single quotes)
    Console.WriteLine($"You entered the symbols: '{string.Join("', '", symbols)}'");
