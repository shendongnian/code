    public static IEnumerable<string> EnumerateLines(this FileInfo file)
    {
        using (var reader = file.OpenText())
        {
            while (!reader.EndOfStream)
            {
                yield return reader.ReadLine();
            }
        }
    }
