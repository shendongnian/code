    public static IEnumerable<string> ReadLines(this StreamReader reader)
    {
        while (!reader.EndOfStream)
        {
            yield return reader.ReadLine();
        }
    }
