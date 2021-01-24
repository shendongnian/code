    public DemographicData GetDemographicByZipCode(string zipcode)
    {
        DemographicData demoData = null;
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
        //Do other stuff to demoData here, if needed
        return demoData;
    }
