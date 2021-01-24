    public string Check(string[] FinalEncryptText)
    {
        for (int i = 0; i < FinalEncryptText.Count; i++)
        {
           //let's say the word you want to match in that array is "whatever"
            if (FinalEncryptText[i] == "whatever")
            {
                 //Do Something
                 return "Found the match: " + FinalEncryptText[i];
            }
        }
    }
