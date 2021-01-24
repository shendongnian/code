    var decoder = Encoding.UTF8.GetDecoder();
    char[] chars = Array.Empty<char>();
    foreach (var byteSegment in bytes)
    {
        int charsMinSize = decoder.GetMaxCharCount(bufferSize);
        if (chars.Length < charsMinSize)
            chars = new char[charsMinSize];
        int numChars = decoder.GetChars(byteSegment, 0, byteSegment.Length, chars, 0);
        Debug.WriteLine(new string(chars, 0, numChars));
    }
