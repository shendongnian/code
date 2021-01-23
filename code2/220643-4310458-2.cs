     private void getAllCustomers()
        {
            // Instantiate a search object for customers. 
            CustomerSearch custSearch = new CustomerSearch();
            CustomerSearchBasic custSearchBasic = new CustomerSearchBasic();
            // Search the customer status which is a list field (16,13,15) 
            String statusKeysValue = "16,13,15";
            SearchMultiSelectField status = null;
            if (statusKeysValue != null && !statusKeysValue.Trim().Equals(""))
            {
                status = new SearchMultiSelectField();
                status.@operator = SearchMultiSelectFieldOperator.anyOf;
                status.operatorSpecified = true;
                string[] nskeys = statusKeysValue.Split(new Char[] { ',' });
                RecordRef[] recordRefs = new RecordRef[statusKeysValue.Length];
                for (int i = 0; i < nskeys.Length; i++)
                {
                    RecordRef recordRef = new RecordRef();
                    recordRef.internalId = nskeys[i];
                    recordRefs[i] = recordRef;
                }
                status.searchValue = recordRefs;
                custSearchBasic.entityStatus = status;
            }
            custSearch.basic = custSearchBasic;
            // Invoke search() web services operation 
            SearchResult response = _service.search(custSearch);
            // Process response 
            if (response.status.isSuccess)
            {
                // Process the records returned in the response 
                // Here I get the first 1000 records 
                processGetAllCustomersResponse(response);
                // Since pagination controls what is returned, check to see 
                // if there are anymore pages to retrieve. 
                List<SearchResult> seachMoreResult = searchMore(response);
                if (seachMoreResult != null)
                {
                    foreach (SearchResult sr in seachMoreResult)
                    {
                        if (sr.status.isSuccess)
                        {
                            // Here I get the next 1000 records 
                            processGetAllCustomersResponse(sr);
                            // My problem now is to get the third set of 1000 customers, then the fourth and so on till I got all 34500 something 
                        }
                        else
                        {
                        }
                    }
                    // Process response 
                    
                }
            }
            else
            {
            }
        }
    private IEnumerable<SearchResult> searchMore(SearchResult response)
        {
            // Keep getting pages until there are no more pages to get    
            int tempTotalRecords = response.totalRecords;
            int pageSize = response.pageSize * response.pageIndex;
            SearchResult tempResponse = null;
            List<SearchResult> records = new List<SearchResult>();
            while (tempTotalRecords > (pageSize))
            {
                SearchResult tempResponse = _service.searchMore(response.pageIndex + 1); 
                if (tempResponse.totalRecords > tempResponse.pageSize * tempResponse.pageIndex)
                {
                    tempTotalRecords = response.totalRecords;
                    pageSize = response.pageSize * response.pageIndex;
                    response = tempResponse;
                    records.Add(response);
                }
                else
                    records.Add(response);
               
            }
            return records;
        }      
