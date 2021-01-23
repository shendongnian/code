    string inputString = "\u00abX\u00bb";
    byte[] encodedBytes = new byte[ae.GetMaxByteCount(inputString.Length)];
    int numberOfEncodedBytes = 0;
    try {
        numberOfEncodedBytes = ae.GetBytes(inputString, 0, inputString.Length, 
                                           encodedBytes, 0);
        }
    catch (EncoderFallbackException e)
        {
        Console.WriteLine("bad conversion");
        }
