        List<RegionList> regions = this.getRegionLists();
        List<AvailabilityList> availability = new List<AvailabilityList>();
        List<Task> tasks = new List<Task>(); 
        List<AvailabilityList> _asyncResults = new List<AvailabilityList>(); 
        regions.ForEach(parent =>
        {
            parent.Regions.ForEach(child =>
            {
                 if (!String.Equals(child.ID, "?"))
                 {
                     int countryID = Int32.Parse(parent.CountryID);
                     var childId = child.ID;
                     Task t = Task.Factory.StartNew((s) =>
                         {
                             var rslt = getExchangeAvailability(countryId, month, year, childId);
                             lock (_asyncResults)
                             {
                                 _asyncResults.Add(rslt);
                             }
                          });
                     tasks.Add(t);
                 }
            }); 
        });
        Task.WaitAll(tasks);
        return _asyncResults; 
    }
