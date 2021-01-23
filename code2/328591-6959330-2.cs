    var allCars = new
    {
        CompanyCars = new List<string[]>(),
        RentalCars = new List<string[]>()
    };
    string myCars = "{\"companycars\":[[\"VIN\",\"LICENSEPLATE\"],[\"VIN\",\"LICENSEPLATE\"]],\"rentalcars\":[[\"VIN\",\"LICENSEPLATE\"],[\"VIN\",\"LICENSEPLATE\"]]}";
    allCars = JsonConvert.DeserializeAnonymousType(myCars, allCars);
