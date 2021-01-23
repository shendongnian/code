    // Optional: create an overload of this taking an encoding
    public IEnumerable<string> ReadLines(string file)
    {
        using (TextReader reader = File.OpenText(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
