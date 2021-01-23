    static string RemoveDiacritics(string input)
    {
        string normalized = input.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder();
    
        for (int ch = 0; ch < normalized.Length; ch++)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(normalized[ch]);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(normalized[ch]);
            }
        }
    
        return (builder.ToString().Normalize(NormalizationForm.FormC));
    }
    string s1 = "Renato Núñez, David DeJesús, and Edwin Encarnación";
    string s2 = RemoveDiacritics(s1);
    // s2 = "Renato Nunez, David DeJesus, and Edwin Encarnacion"
