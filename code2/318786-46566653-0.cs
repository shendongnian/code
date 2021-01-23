    public static string EncodeString(string str)
    {
        //maxLengthAllowed .NET < 4.5 = 32765;
        //maxLengthAllowed .NET >= 4.5 = 65519;
        int maxLengthAllowed = 65519;
        StringBuilder sb = new StringBuilder();
        int loops = str.Length / maxLengthAllowed;
 
        for (int i = 0; i <= loops; i++)
        {
            sb.Append(Uri.EscapeDataString(i < loops
                ? str.Substring(maxLengthAllowed * i, maxLengthAllowed)
                : str.Substring(maxLengthAllowed * i)));
        }
 
        return sb.ToString();
    }
    
    public static string DecodeString(string encodedString)
    {
        //maxLengthAllowed .NET < 4.5 = 32765;
        //maxLengthAllowed .NET >= 4.5 = 65519;
        int maxLengthAllowed = 65519;
 
        int charsProcessed = 0;
        StringBuilder sb = new StringBuilder();
 
        while (encodedString.Length > charsProcessed)
        {
            var stringToUnescape = encodedString.Substring(charsProcessed).Length > maxLengthAllowed
                ? encodedString.Substring(charsProcessed, maxLengthAllowed)
                : encodedString.Substring(charsProcessed);
 
            // If the loop cut an encoded tag (%xx), we cut before the encoded char to not loose the entire char for decoding
            var incorrectStrPos = stringToUnescape.Length == maxLengthAllowed ? stringToUnescape.IndexOf("%", stringToUnescape.Length - 4, StringComparison.InvariantCulture) : -1;
            if (incorrectStrPos > -1)
            {
                stringToUnescape = encodedString.Substring(charsProcessed).Length > incorrectStrPos
                    ? encodedString.Substring(charsProcessed, incorrectStrPos)
                    : encodedString.Substring(charsProcessed);
            }
 
            sb.Append(Uri.UnescapeDataString(stringToUnescape));
            charsProcessed += stringToUnescape.Length;
        }
 
        var decodedString = sb.ToString();
        // ensure the string is sanitized here or throw exception if XSS / SQL Injection is found
        SQLHelper.SecureString(decodedString);
        return decodedString;
    }
