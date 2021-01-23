        /// <summary>
        /// Return the list of time bills whose last modified date is within 
        /// the indicated date range.
        /// </summary>
        /// <param name="from">Required from date</param>
        /// <param name="to">Optional to date</param>
        /// <returns>List of time bills</returns>
        public IEnumerable<TimeBill> GetTimeBills(DateTime from, DateTime to)
        {
            _log.Debug(String.Format("Enter TimeBill(DateTime from='{0}', DateTime to='{1}')", from, to));
            // Build search criteria.
            TimeBillSearch search = new TimeBillSearch();
            TimeBillSearchBasic searchBasic = new TimeBillSearchBasic();
            SearchDateField searchDateField = new SearchDateField();
            searchDateField.@operator = SearchDateFieldOperator.within;
            searchDateField.operatorSpecified = true;
            searchDateField.searchValue = from;
            searchDateField.searchValueSpecified = true;
            searchDateField.searchValue2 = to;
            searchDateField.searchValue2Specified = true;
            searchBasic.dateCreated = searchDateField;
            search.basic = searchBasic;
            return this.Get<TimeBill>(search);
        }  
        
        /// <summary>
        /// Perform a paged search and convert the returned record to the indicated type.
        /// </summary>
        private IEnumerable<T> Get<T>(SearchRecord searchRecord)
        {
            _log.Debug("Enter Get<T>(SearchRecord searchRecord)");
            // This is returned.
            List<T> list = new List<T>();
            // The suitetalk service return this.
            SearchResult result = null;
            using (ISuiteTalkService service = SuiteTalkFactory.Get<SuiteTalkService>())
            {
                do
                {
                    // .search returns the first page of data.
                    if (result == null)
                    {
                        result = service.search(searchRecord);
                    }
                    else // .searchMore returns the next page(s) of data.
                    {
                        result = service.searchMoreWithId(result.searchId, result.pageIndex + 1);
                    }
                    if (result.status.isSuccess)
                    {
                        foreach (Record record in result.recordList)
                        {
                            if (record is T)
                            {
                                list.Add((T)Convert.ChangeType(record, typeof(T)));
                            }
                        }
                    }
                }
                while (result.pageIndex < result.totalPages);
            }
            return list;
        }
