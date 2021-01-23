    static string GetFirstLine(string text)
    {
        using (var reader = new StringReader(text))
        {
            return reader.ReadLine();
        }
    }
