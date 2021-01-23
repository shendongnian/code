    Encoding encoding = Encoding.UTF8;
    try
    {
        if (response != null && !string.IsNullOrEmpty(response.CharacterSet))
            encoding = Encoding.GetEncoding(response.CharacterSet);
    }
    catch (ArgumentException)
    {
        // Cannot determine encoding, use assigned above
    }
    
    StreamReader reader = new StreamReader(response.GetResponseStream(), encoding);
            string sourceCode = reader.ReadToEnd();
