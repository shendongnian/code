    /// <summary> 
    /// Calls matching process error code on response.Code 
    /// </summary> 
    /// <param name="response">Actually will be of type Response or extend it</param> 
    /// <returns>true for successful response, false otherwise</returns> 
    private static bool ProcessErrorCode(object response) 
    { 
        bool isOkay = false; 
        const string unknown = "UNKNOWN"; 
        string errCode = unknown; 
        Response<AResponseCode> resp1 = null;
        
        if ((resp1 = response as Response<AResponseCode>) != null) 
        { 
            AResponseCode code = resp1.Code; 
            isOkay = code == AResponseCode.Ok; 
            errCode = code.ToString(); 
        }
        Response<BResponseCode> resp2 = null;
        if ((resp2 = response as Response<BResponseCode>) != null) 
        { 
            BResponseCode code = resp2.Code; 
            isOkay = code == BResponseCode.Ok; 
            errCode = code.ToString(); 
        } 
        DataResponse<CResponseCode, string> resp3 = null;
        if ((resp3 = response as DataResponse<CResponseCode,string>)!=null) 
        { 
            CResponseCode code = resp3.Code; 
            isOkay = code == CResponseCode.Ok; 
            errCode = code.ToString(); 
        } 
        if (isOkay) 
        { 
            return true; 
        } 
        string msg = "Operation resulted in error code:" + errCode; 
        LogErrorCode(msg); 
        return false; 
    }
