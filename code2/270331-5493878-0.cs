    // Turns every occurrence of \uXXXX into a proper character
    void UnencodeJSONUnicode(string str) {
        return Regex.Replace(str,
                             @"\\u(?<value>[0-9a-f]{4})",
                             match => {
                                 string digits = match.Groups["value"].Value;
                                 int number = int.Parse(digits, NumberStyles.HexNumber);
                                 return char.ConvertFromUtf32(number);
                             }
    }
