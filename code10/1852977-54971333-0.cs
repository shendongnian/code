    var decoder = Encoding.UTF8.GetDecoder();
    char[] chars = decoder.GetMaxCharCount(bufferSize);
    foreach (var byteSegment in bytes)
    {
        int numChars = decoder.GetChars(byteSegment, 0, byteSegment.Length, chars, 0);
        Debug.WriteLine(new string(chars, 0, numChars));
    }
