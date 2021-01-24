        Regex[] regexCollection = new Regex[4];
 
        Regex intRegex = new Regex(@"((?<!\S)[A-Za-z]{2}\d{1,5}\S+\s+)|(\s[A-Za-z]{7,15}\d{1,5}\S+\s+)", RegexOptions.Compiled);
        Regex psRegex = new Regex(@", id\s+\d{10},", RegexOptions.Compiled);
        Regex cidRegex = new Regex(@"\d{3}-\d{3}-\d{4}", RegexOptions.Compiled);
        Regex vcidRegex = new Regex(@"vcid\s\d{10},", RegexOptions.Compiled);
        regexCollection[0] = intRegex;
        regexCollection[1] = psRegex;
        regexCollection[2] = intRegex;
        regexCollection[3] = vcidRegex;
