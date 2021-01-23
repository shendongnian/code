    using (YourEntities context = getYourContextHere())
    {
    var countryEntity = context.CountryEntitySet.FirstOrDefault(country => country.id == newCityCountryId);
    
    if (countryEntity == null)
      throw new InvalidOperationException();
    
    CityEntity newCity = createYourCityEntity();
    newCity.Country = countryEntity;
    
    context.SaveChanges();
    }
