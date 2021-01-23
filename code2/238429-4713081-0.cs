    string pattern = @"(?<decimal>[0-9]{0,3}(\s[0-9]{3})*(.[0-9]+){0,1})\s" +
                     @"(?<currency>[a-zA-Z]+){1}";
    
    string input = "302 600.00 RUB\r\n10 000.00 USD"; 
    
    // Get text that matches regular expression pattern.
    MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
    
    NumberFormatInfo format = new NumberFormatInfo();
    format.NumberGroupSeparator = " ";
    format.NumberDecimalSeparator = ".";
    format.NumberDecimalDigits = 2;
    
    Dictionary<string, decimal> dictionary = new Dictionary<string, decimal>();
    foreach (Match match in matches)
    {
        dictionary.Add(match.Groups["currency"].Value, Decimal.Parse(match.Groups["decimal"].Value, format));      
    }
    if (dictionary.Count > 0)
    {
        foreach (KeyValuePair<string, decimal> item in dictionary)
        {
            Console.WriteLine("Currency : {0} Amount: {1}", item.Key, item.Value);
        }
    }
