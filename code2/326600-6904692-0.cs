    System.Text.RegularExpressions.Regex myFileRegex = new Regex(@"_(\d+)\.dwg", RegexOptions.IgnoreCase);
    SortedDictionary<string, int> fileFromNumber= new SortedDictionary<int, string>();
    foreach (string filePath in Direcoty.GetFiles(@"you directory path")
    {
        Match match = myFileRegex.Match(fileName);
        if (match.Groups.Count > 1)
        {
            fileFromNumber.Add(Convert.ToInt32(match.Groups[1].Value), filePath);
        }
    }
    string newestFile = fileFromNumber[fileFromNumber.Count - 1];//the last element
