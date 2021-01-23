    public IQueryable<CityPM> GetCities(string provinceName)
    {
        return this.ObjectContext.ZipCodes.Where(z => z.Province.ToLower().Contains(provinceName.ToLower()))
                                          .GroupBy(z => z.City)
                                          .Select(g => g.FirstOrDefault())
                                          .Select(zc => new CityPM() { ID = zc.ID, Name = zc.City })
                                          .TraceSql();
    }
