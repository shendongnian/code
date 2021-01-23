    public GetRecordsResponse GetRecords(GetRecordsRequest request, DataAccessService dataAccess)
            {
                var response = new GetRecordsResponse();
                
                Util.GetRecords.VerifyMandatoryParameters(request);
                Util.GetRecords.SetDefaultValues(request);    
                Util.GetRecords.SetDefaultResponseValues(request, response);
                   
                dataAccess.GetAllRecords(request, response);
    
                return response;
            }
