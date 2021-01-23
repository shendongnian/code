    public ReadOnlyCollection<string> GetLinks()
    {
        string startingText = "href=''";
        string endText = "''>";
        string stopText = "Fixed_String";
        string someText = @"what is this text <a href=''/link/i/want''>somenormallink</a> some random text <a href=''/another link/i/want''>Fixed_String</a> some more radnom txt ";
    
        List<string> myLinks = new List<string>();
    
        string[] rawLinks = someText.Split(new string[] { "<a " }, StringSplitOptions.None);
    
        foreach (string rawLink in rawLinks)
        {
            if (!rawLink.StartsWith(startingText))
            {
                continue;
            }
    
            myLinks.Add(rawLink.Substring(startingText.Length, rawLink.IndexOf(endText, 1) - startingText.Length));
    
    
            if (rawLink.Contains(stopText))
            {
                break;
            }
        }
    
    
        return new ReadOnlyCollection<string>(myLinks);
    }
