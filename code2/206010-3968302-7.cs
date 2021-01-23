    public static bool StringIsValid(string input, int expectedLineLength)
    {
        return input.Replace("\r\n", "").Length % expectedLineLength == 0;
    }
    // called like so:
    if (StringIsValid(str, 94))
    {
       // do something
    }
