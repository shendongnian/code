        protected string GetCountryCode(string country)
        {
            var v1 = (from c in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                      where (new RegionInfo(c.LCID)).EnglishName != ""
                      || (new RegionInfo(c.LCID)).EnglishName != null
                      orderby (new RegionInfo(c.LCID)).EnglishName ascending
                      select new
                      {
                          Code = (new RegionInfo(c.LCID)).TwoLetterISORegionName,
                          Name = (new RegionInfo(c.LCID)).EnglishName
                      }).Distinct();
            string code = v1.Where(t => t.Name.ToLower() == country.ToLower()).FirstOrDefault().Code;
            if (!string.IsNullOrEmpty(code))
                return code;
            else return "";
        }
