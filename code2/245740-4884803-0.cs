    public CultureInfo GetCultureFromThreeLetterISO(string name)
    {
        if (name.Length != 3)
        {
            throw new ArgumentException("name must be three letters.");
        }
        name = name.ToUpper();
        CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
        foreach (CultureInfo culture in cultures)
        {
            if (name == culture.ThreeLetterISOLanguageName.ToUpper())
            {
                return culture;
            }
        }
        return null;
    }
