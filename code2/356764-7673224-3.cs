    // Like File.ReadLines in .NET 4 - except that's broken (see comments)
    public IEnumerable<string> ReadLines(string filename)
    {
        using (TextReader reader = File.OpenText(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
