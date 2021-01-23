        public ObservableCollection<PlumFile> FoundFiles
        {
            get
            {
                ObservableCollection<PlumFile> searchResults = new ObservableCollection<PlumFile>();
    
                // get the data source
                IEnumerable<PlumFile> query = PlumData.GetFiles();
    
                foreach (FilterConstraint filter in filters)
                {
                    var localFilter = filter;
                    // debugging
                    IList<PlumFile> oldQuery = query.ToList();
    
                    switch (filter.QueryCombiningRule)
                    {
                        case FilterConstraint.QueryRule.And:
                            query = query.Where(file => filter.Fits(file));
                            break;
                        case FilterConstraint.QueryRule.Or:
                            query = query.Concat(PlumData.GetFiles().Where(file => localFilter.Fits(file)));
                            break;
    
                        // is this really how I want to do 'not'?
                        case FilterConstraint.QueryRule.Not:
                            query = query.Where(file => !localFilter.Fits(file));
                            break;
                    }
    
                    // debugging
                    IList<PlumFile> currQuery = query.ToList();
    
                }
    
                query = query.Distinct();
    
                foreach (PlumFile file in query)
                {
                    searchResults.Add(file);
                }
    
                return searchResults;
            }
        }
