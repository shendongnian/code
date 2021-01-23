    // Like File.ReadLines in .NET 4
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
