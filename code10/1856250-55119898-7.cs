    Dictionary<string, string> dotNotation = new Dictionary<string, string>
    {
        {"Company.Website", "Hjemmeside"},
        {"Company.TextHeaderPlaceholder", "Firmanavn"},
        {"Company.User.Manager.Repositories.CreateAsync.ArgumentNullException.InvalidCompanyId", "firma id fejl"},
        {"BookingSettings.HelpText", "Hjælpe tekst på webshop"},
        {"BookingSettings.OnGoingOrderValidation.Text", "Bestillings validering i gang"},
        {"BookingSettings.OnGoingOrderValidation.Created", "Oprettet"},
        {"BookingSettings.Url", "Kundelink til booking"}
    };
    var betterDictionary = DotNotationToDictionary(dotNotation);
    var json = JsonConvert.SerializeObject(betterDictionary);
    Console.WriteLine(json);
    
