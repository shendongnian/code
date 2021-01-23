    var country = registryCountryRepository.FindAllRegistryCountries().SingleOrDefault(c => c.Name == model.Country);
    if (country == null) 
    { 
        RegistryCountry newCountry = new RegistryCountry(); 
        newCountry.Name = model.Country; 
        registryCountryRepository.AddRegistryCountry(newCountry); 
        registryCountryRepository.SaveChanges(); 
        **country = newCountry**
    } 
