    System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(Radeditor1.Content, @"\<title[^\<]*\>(?<content>.*?)\<\/title\>", RegexOptions.Multiline);
    if (match.Success)
    {
         string content = match.Groups["content"].Value;
    }
