    public string ConvertThreeLetterNameToTwoLetterName(string name)
    {
        if (name.Length != 3)
        {
            throw new ArgumentException("name must be three letters.");
        }
        name = name.ToUpper();
        CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        foreach (CultureInfo culture in cultures)
        {
            RegionInfo region = new RegionInfo(culture.LCID);
            if (region.ThreeLetterISORegionName.ToUpper() == name)
            {
                return region.TwoLetterISORegionName;
            }
        }
        return null;
    }
