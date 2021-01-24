    		SearchFilter internetMessageIdFilter = new SearchFilter.IsEqualTo(PidTagInternetMessageId, InternetMessageId);
			SearchFilter DateTimeFilter = new SearchFilter.IsGreaterThan(EmailMessageSchema.DateTimeReceived, DateTime.Now.AddDays(-1));
            SearchFilter.SearchFilterCollection searchFilterCollection= new SearchFilter.SearchFilterCollection(LogicalOperator.And);
			searchFilterCollection.Add(internetMessageIdFilter);
			searchFilterCollection.Add(DateTimeFilter);
