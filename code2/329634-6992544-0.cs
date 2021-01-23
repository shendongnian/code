    string s = "#Hi this          is  rèally/ special strìng!!!";
    string normalized = s.Normalize(NormalizationForm.FormD);
    
    
    StringBuilder resultBuilder = new StringBuilder();
    foreach (var character in normalized)
    {
        UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(character);
        if (category == UnicodeCategory.LowercaseLetter
            || category == UnicodeCategory.UppercaseLetter
            || category == UnicodeCategory.SpaceSeparator)
            resultBuilder.Append(character);
    }
    string result = Regex.Replace(resultBuilder.ToString(), @"\s+", "-");
