        //other code
        
        string filter_string = string.Empty;
    
        TableQuery<T> query = new TableQuery<T>();            
        
        string myfilter = TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "xxx"),
                                                    TableOperators.And,                                                   
                                                    TableQuery.GenerateFilterCondition("Email", QueryComparisons.Equal, "xxx@hotmail.com"));
        
        query.FilterString = myfilter;
        
        
        //other code
