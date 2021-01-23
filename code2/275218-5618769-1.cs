    public IEnumerable<string> ReadAllLines(string filename, Encoding encoding)
    {
        using (var reader = new StreamReader(filename, encoding))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
