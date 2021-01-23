    public CultureInfo GetCultureFromThreeLetterISO(string name)
    {
        if (name.Length != 3)
        {
            throw new ArgumentException("name must be three letters.");
        }
        name = name.ToUpper();
        CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
        
        return cultures.FirstOrDefault(c => 
            c.ThreeLetterISOLanguageName.ToUpper() == name);
    }
