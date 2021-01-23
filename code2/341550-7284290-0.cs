    public IEnumerable<string> GetAllCitiesOfCountry(int id)
        {
            var ad = from a in entities.Addresses
                     where a.CountryID == id
                     select a.City.Distinct();
            var fa = from b in entities.FacilityAddresses
                     where b.CountryID == id
                     select b.City.Distinct();
            return ad.Concat(fa).Distinct().AsEnumerable().Select(x => x.ToString());
        }
