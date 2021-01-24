    public static IEnumerable<string> ReadLines(this string fileName)
    {
        // TODO: check fileName not null, empty; check file exists
        FileInfo file = new FileInfo(fileName);
        using (TextReader reader = file.OpenText())
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                yield return line;
                line = reader.ReadLine();
            }
        }
