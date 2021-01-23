    public List<string> LoadDictionary(string filename)
    {
        List<string> wordsDictionary = new List<string>();
        Encoding enc = Encoding.GetEncoding(1250);
        string[] lines = File.ReadAllLines(filename,enc);
        wordsDictionary.AddRange(lines.Where(x => x.Length > 2));
        return wordsDictionary;
    }
