    public DemographicData GetDemographicByZipCode(string zipcode)
    {
        DemographicData demoData = null;
        // Instantiate to new instance in the select method.
        using(var context = new DataContext())
        {
            demoData = (from item in context.Demographic
                       where item.ZipCode == zipcode
                       select new DemographicData()
                       {
                           Zip = item.ZipCode,
                           City = item.City,
                           State = item.State
                       }).FirstOrDefault();
        }
        return demoData;
    }
