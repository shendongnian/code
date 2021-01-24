    string link = "";
    string patternHref = "href=\"(?:[^\"]*)\"";
    string patternSrc = "src=\"(?:[^\"]*)\"";
    var matches = Regex.Matches(link, patternSrc, RegexOptions.IgnoreCase);
        foreach(Match ma in matches)
        {
            var matches2 = Regex.Matches(ma.Value, "(?! src=\")[^\"]*[^\"]*", RegexOptions.IgnoreCase);
            foreach (Match ma2 in matches2)
            {
                if(!ma2.Value.Contains("src=") && !ma2.Value.Contains("href=") && !string.IsNullOrWhiteSpace(ma2.Value))
                    Console.WriteLine(ma2.Value); //assign value to variable here 
            }
        }
