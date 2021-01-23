            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            List<string> CountryCodes = new List<string>();
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo ri = new RegionInfo(ci.LCID);
                CountryCodes.Add(ri.ISOCurrencySymbol);
            }
            string [] CountryCodeArray = CountryCodes.Distinct().ToArray();
