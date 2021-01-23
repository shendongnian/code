    Regex re = new Regex("[a-zA-Z0-9_-]+", RegexOptions.Compiled); // You'll need to change the RE to fit your needs
    Match m = re.Match(text);
    while (m.Success)
    {
        string word = m.Groups[1].Value;
    
        // do your processing here
        m = m.NextMatch();
    }
