    var decoder = Encoding.UTF8.GetDecoder();
    var sb = new StringBuilder();
    var processed = 0L;
    var total = bytes.Length;
    foreach (var i in bytes)
    {
        processed += i.Length;
        var isLast = processed == total;
        var span = i.Span;
        var charCount = decoder.GetCharCount(span, isLast);
        Span<char> buffer = stackalloc char[charCount];
        decoder.GetChars(span, buffer, isLast);
        sb.Append(buffer);
    }
