    var decoder = Encoding.UTF8.GetDecoder();
    // +1 in case it includes a work-in-progress char from the previous buffer
    char[] chars = decoder.GetMaxCharCount(bufferSize) + 1;
    foreach (var byteSegment in bytes)
    {
        int numChars = decoder.GetChars(byteSegment, 0, byteSegment.Length, chars, 0);
        Debug.WriteLine(new string(chars, 0, numChars));
    }
