    public string GetCurrencySymbolFromAbbreviation(string abbreviation)
    {
        foreach (CultureInfo nfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
        {
            RegionInfo region = new RegionInfo(nfo.LCID);
            if (region.ISOCurrencySymbol == abbreviation)
            {
                return region.CurrencySymbol;
            }
        }
        return null;
    }
