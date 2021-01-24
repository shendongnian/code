    static void Main(string[] args)
    {
        var s = "CBC004DS009";
        // get the very last index of the character that is not a number
        var lastNonNumeric = s.LastOrDefault(c => !char.IsDigit(c)); 
        if (lastNonNumeric != '\x0000')
        {
            var numericStart = s.LastIndexOf(lastNonNumeric);
            // grab the number chunk from the string based on the last character found
            var numericValueString = s.Substring(numericStart + 1, s.Length - numericStart - 1);
            // convert that number so we can increment accordingly
            if (int.TryParse(numericValueString, out var newValue))
            {
                newValue += 1;
                // create the new string without the number chunk at the end
                var newString = s.Substring(0, s.Length - numericValueString.Length);
                // append the newly increment number to the end of the string, and pad
                // accordingly based on the original number scheme
                newString += newValue.ToString().PadLeft(numericValueString.Length, '0');
                Console.WriteLine(newString);
            }
        }
    }
