    public string Check(string[] FinalEncryptText)
    {
        foreach (string i in FinalEncryptText)
        {
           //let's say the word you want to match in that array is "whatever"
            if (i == "whatever")
            {
                 return "Found the match: " + i;
            }
        }
    }
