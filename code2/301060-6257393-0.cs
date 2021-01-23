    //A REGEX value, this one finds proper http address'
    Regex regexObj = new Regex(@"^http\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$");
    while (parse.ParseNext("a", out tag))
    {
        string value;
    
        if (tag.Attributes.TryGetValue("href", out value))
        {
            string value2;
            //Start finding matches...
            Match matchResult = regexObj.Match(value);
            if (matchResult.Success)
            {
                value2 = matchResult.Value;
                lstPages.AppendText(value2 + "\r\n");
            }
        }
    }
