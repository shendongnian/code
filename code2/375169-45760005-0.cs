    String content = "stuff";
    using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content)))
    {
        Print(stream); //or whatever action you need to perform with the stream
        stream.Seek(0, SeekOrigin.Begin); //If you need to use the same stream again, don't forget to reset it.
        UseAgain(stream);
        using (var readr = new StreamReader(stream))
        {
            UseAsString(readr.ReadToEnd());
        }
    }
