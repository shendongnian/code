    private Encoding _encoding;
    private Decoder _decoder;
    private char[] _charData = new char[4];
    public PushTextReader(Encoding encoding)
    {
        _encoding = encoding;
        _decoder = _encoding.GetDecoder();
    }
    // A single connection requires its own decoder
    // and charData. That connection should never
    // call this method from multiple threads
    // simultaneously.
    // If you are using the ReadAsyncLoop you
    // don't need to worry about it.
    public void ReceiveData(ArraySegment<byte> data)
    {
        // The two false parameters cause the decoder
        // to accept 'partial' characters.
        var charCount = _decoder.GetCharCount(data.Array, data.Offset, data.Count, false);
        charCount = _decoder.GetChars(data.Array, data.Offset, data.Count, _charData, 0, false);
        OnCharacterData(new ArraySegment<char>(_charData, 0, charCount));
    }
