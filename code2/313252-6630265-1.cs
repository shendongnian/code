    string range = context.Request.Headers["Range"];
    int rangeBegin = 0;
    int rangeEnd = msg.Length;
    if (range != null)
    {
        string[] byteRange = range.Replace("bytes=", "").Split('-');
        Int32.TryParse(byteRange[0], out rangeBegin);
        if (byteRange.Length > 1 && !string.IsNullOrEmpty(byteRange[1]))
        {
           Int32.TryParse(byteRange[1], out rangeEnd);
        }
    }
    context.Response.ContentLength64 = rangeEnd - rangeBegin;
    using (Stream s = context.Response.OutputStream)
    {
        s.Write(msg, rangeBegin, rangeEnd - rangeBegin);
    }
