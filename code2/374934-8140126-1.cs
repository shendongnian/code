    protected void sendSoapMessage()
    {
        using (var client = new RegistrationBindingsClient("RegistrationBindings"))
        {
            var registration = new RegistrationType();
            registration.Source = new SourceType();
            registration.Source.SourceID = "50001255";
            registration.Email = "adsvine@gmail.com";
            registration.FirstName = "Muz";
            registration.LastName = "Khan";
            var countryUK = new CountryTypeUK();
            countryUK.CountryID = 2000077;
            countryUK.Language = 2000240;
            countryUK.Address = new AddressTypeUK();
            countryUK.Address.Postalcode = "N19 3NU";
            registration.Item = countryUK;
            registration.DOB = new DateTime(1977, 3, 8);
            registration.Gender = 2000247;
            client.SubmitPanelist(registration);
        }
    }
