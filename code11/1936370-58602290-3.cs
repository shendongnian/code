            var Result = (from p in response
                               select  (from z in p["ClientInfo"]
                                             where (int)z["InternalID"] == 98368
                                             select new
                                             {
                                                 ProviderTransactionID = (string)p["ProviderTransactionID"],
                                                 InternalID = (int)z["InternalID"],
                                                 UniqueID = (string)z["UniqueID"],
                                                 ErrorMessages = (string)z["ErrorMessages"],
                                             }
                                             ).ToList()
                               ).ToList();
