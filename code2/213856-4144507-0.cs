    private string Convert(string source)
    {
        string arabicWord = string.Empty;
        StringBuilder sbDestination = new StringBuilder();
    
        foreach (var ch in source)
        {
            if (IsArabic(ch))
                arabicWord += ch;
            else
            {
                if (arabicWord != string.Empty)
                    sbDestination.Append(Reverse(arabicWord));
    
                sbDestination.Append(ch);
                arabicWord = string.Empty;
            }
        }
        // if the last word was arabic    
        if (arabicWord != string.Empty)
            sbDestination.Append(Reverse(arabicWord));
    
        return sbDestination.ToString();
    }
    
