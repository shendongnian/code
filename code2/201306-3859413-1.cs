    // The input string consists of the Unicode characters LEFT POINTING 
    // DOUBLE ANGLE QUOTATION MARK (U+00AB), 'X' (U+0058), and RIGHT POINTING 
    // DOUBLE ANGLE QUOTATION MARK (U+00BB). 
    // The encoding can only encode characters in the US-ASCII range of U+0000 
    // through U+007F. Consequently, the characters bracketing the 'X' character
    // cause an exception.
    string inputString = "\u00abX\u00bb";
    byte[] encodedBytes = new byte[ae.GetMaxByteCount(inputString.Length)];
    int numberOfEncodedBytes = 0;
    try
    {
        numberOfEncodedBytes = ae.GetBytes(inputString, 0, inputString.Length, 
                                           encodedBytes, 0);
    }
    catch (EncoderFallbackException e)
    {
        Console.WriteLine("bad conversion");
    }
