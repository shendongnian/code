    public IQueryable<CityPM> GetCities(string provinceName)
    {
        var lowerProvinceName = String.IsNullOrEmpty(provinceName) ? string.Empty : provinceName.ToLower();
        return this.ObjectContext.ZipCodes.Where(z => z.Province.ToLower().Contains(lowerProvinceName))
                                          .GroupBy(z => z.City)
                                          .Select(g => g.FirstOrDefault())
                                          .Select(zc => new CityPM() { ID = zc.ID, Name = zc.City });
    }
