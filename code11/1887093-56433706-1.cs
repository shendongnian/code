     var b = proxy.GetBatchInfo(batchid);
                          
     while (b.BatchStatus != CRB_WEBSERVICE.CBS_SERVICE.BatchStatuses.Finished)
                            {
                                b = proxy.GetBatchInfo(batchid);
                            }
    if (b.BatchStatus == CRB_WEBSERVICE.CBS_SERVICE.BatchStatuses.Finished)
                            {
                                if (b.BatchResult == CRB_WEBSERVICE.CBS_SERVICE.BatchResults.Success)
                                {  
                                    var result = proxy.GetResponseData(batchid, 1);
    }
    }
