    string[] lines = File.ReadAllLines("path to your text file");
    Regex regex = new Regex("^pattern$");
    foreach (string line in lines)
    {
        Match match = regex.Match(line.Trim())
        if (match.Successful)
        {
             // have your match here.
        }
    }
