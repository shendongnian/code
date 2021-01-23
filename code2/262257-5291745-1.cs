    Action action = delegate
    {
        TextRange tr = new TextRange(document.ContentStart,
                                              document.ContentEnd);
        using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(text)))
        {
            tr.Load(ms, DataFormats.Rtf);
        }
    };
