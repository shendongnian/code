    var decoder = Encoding.UTF8.GetDecoder();
    char[] chars = Array.Empty<char>();
    foreach (var byteSegment in bytes)
    {
        // +1 in case it includes a work-in-progress char from the previous buffer
        int charsMinSize = decoder.GetMaxCharCount(bufferSize) + 1;
        if (chars.Length < charsMinSize)
            chars = new char[charsMinSize];
        int numChars = decoder.GetChars(byteSegment, 0, byteSegment.Length, chars, 0);
        Debug.WriteLine(new string(chars, 0, numChars));
    }
