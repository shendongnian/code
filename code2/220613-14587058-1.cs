    [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SearchResultsLift>
            GetSearchResults(
            int liftID,
            string sortType,
            int range
            )
        {        
        List<SearchResultsLift> returnList =
            new List<SearchResultsLift>();
            ...Code to populate list...
            if (range != 0)
            returnList = FilterByRange(returnList, range);
        
            returnList = GetListSort(returnList, sortType);
        return returnList;
    }
