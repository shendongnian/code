    Regex regex = new Regex(@"^\(([^)]+)\)\s+(.+)$");
    string[] lines = File.ReadAllLines(pathToFile);
    foreach (string line in lines)
    {
        Match match = regex.Match(line);
        if (match.Success)
        {
            string key = match.Groups[1].Value;
            string value = match.Groups[2].Value;
        }
    }
