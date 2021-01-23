            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            List<string> CountryCodes = new List<string>();
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo ri = new RegionInfo(ci.LCID);
                CountryCodes.Add(ri.ISOCurrencySymbol);
            }
            string [] CountryCodeArray = GetDistinctValues(CountryCodes.ToArray());
    public string[] GetDistinctValues(string[] array)
    {
        List<string> list = new List<string>();
 
        for (int i = 0; i < array.Length; i++)
        {
            if (list.Contains(array[i]))
                continue;
            list.Add(array[i]);
        }
        return list.ToArray();
    }
