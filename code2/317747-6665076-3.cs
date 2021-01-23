    static string RemoveDiacritics(string input)
    {
        string normalized = input.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder();
    
        foreach (char ch in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(ch);
            }
        }
    
        return builder.ToString().Normalize(NormalizationForm.FormC);
    }
    string s1 = "Renato Núñez David DeJesús Edwin Encarnación";
    string s2 = RemoveDiacritics(s1);
    // s2 = "Renato Nunez David DeJesus Edwin Encarnacion"
