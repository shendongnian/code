    public string RemoveDiacritics(string input)
    {
        string stFormD = input.Normalize(NormalizationForm.FormD);
        int len = stFormD.Length;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < len; i++)
        {
            System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
            if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                sb.Append(stFormD[i]);
            }
        }
        return (sb.ToString().Normalize(NormalizationForm.FormC));
    }
