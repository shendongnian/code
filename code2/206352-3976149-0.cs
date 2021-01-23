    public static IEnumerable<string> GetStuff(string fileName)
    {
        var regex = new Regex(@"Stuff[^\s]*.rar");
        using (var reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    yield return match.Value;
                }
            }
        }
    }
