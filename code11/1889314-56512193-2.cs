    public string Check(string stringToMatch)
    {
        for (int i = 0; i < FinalEncryptText.Count; i++)
        {
           //this will match whatever string you pass into the parameter
            if (FinalEncryptText[i] == stringToMatch)
            {
                 //Do Something
                 return "Found the match: " + FinalEncryptText[i];
            }
        }
    }
