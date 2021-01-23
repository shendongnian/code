        public List<AvailabilityList> _asyncGetResortsForDate(String month, int year)
        {
            List<RegionList> regions = this.getRegionLists();
            List<AvailabilityList> availability = new List<AvailabilityList>();
            List<WaitHandle> handles = new List<WaitHandle>(); 
            List<AvailabilityList> _asyncResults = new List<AvailabilityList>(); 
            regions.ForEach(parent =>
            {
                parent.Regions.ForEach(child =>
                {
                     if (!String.Equals(child.ID, "?"))
                     {
                         int countryID = Int32.Parse(parent.CountryID);
                         Func<AvailabilityList> _getList = 
                            () => this.getExchangeAvailability(countryID, month, year, child.ID);
                         IAsyncResult res = _getList.BeginInvoke(new AsyncCallback(
                          x =>
                          {
                              AvailabilityList result = 
                                (x.AsyncState as Func<AvailabilityList>).EndInvoke(x);
                                    
                              _asyncResults.Add(result);
                          }), _getList);
                         handles.Add(res.AsyncWaitHandle); 
                     }
                }); 
            });
            WaitHandle.WaitAll(handles.ToArray());
            return _asyncResults; 
        }
