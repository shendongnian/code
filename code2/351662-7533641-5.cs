        public List<AvailabilityList> _getAllChildren(RegionList parent, string month, int year)
        {
            List<AvailabilityList> list = new List<AvailabilityList>(); 
            parent.Regions.ForEach(child =>
            {
                if (!String.Equals(child.ID, "?"))
                {
                    int countryID = Int32.Parse(parent.CountryID);
                    AvailabilityList result = this.getExchangeAvailability(countryID, month, year, child.ID);
                    list.Add(result); 
                }
            });
            return list; 
        }
        public List<AvailabilityList> _asyncGetResortsForDate(String month, int year)
        {
            List<RegionList> regions = this.getRegionLists();
            List<AvailabilityList> availability = new List<AvailabilityList>();
            List<WaitHandle> handles = new List<WaitHandle>();
            List<AvailabilityList> _asyncResults = new List<AvailabilityList>(); 
            regions.ForEach(parent =>
            {
                Func<List<AvailabilityList>> allChildren = () => _getAllChildren(parent, month, year);
                IAsyncResult res = allChildren.BeginInvoke(new AsyncCallback(
                          x =>
                          {
                              List<AvailabilityList> result =
                                (x.AsyncState as Func<List<AvailabilityList>>).EndInvoke(x);
                              _asyncResults.AddRange(result);
                          }), allChildren);
                handles.Add(res.AsyncWaitHandle); 
            });
            WaitHandle.WaitAll(handles.ToArray());
            return _asyncResults; 
        }
    
