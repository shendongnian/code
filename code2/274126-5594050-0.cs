    using System.IO;
    using System.Text.RegularExpressions;
    public List<string> NaiveExtractor(string path)
    {
        return 
        File.ReadAllLines(path)
            .Select(l => Regex.Replace(l, @"[^\d]", ""))
            .Where(s => s.Length > 0)
            .ToList();
    }
