     private async Task<List<DeviceTrackListResponse>> GetDeviceTrackListData(string accessToken, string imei, DateTime startDate, DateTime endDate)
    {
        var client = new RestClient(_security.EndPoint);
        var webRequest = new RestRequest(Method.POST);
    
        var requiredParams = new DeviceTrackListRequest(accessToken)
        {
            app_key = _security.AppKey,
            imei = imei,
            method = "jimi.device.track.list",
            begin_time = startDate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss"),
            end_time = endDate.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")
        };
    
        webRequest.AddObject(requiredParams);
    
        try
        {
            var signature = Signature.SignTopRequest(requiredParams.GetProperties(), _security.SecurityToken, requiredParams.sign_method);
            webRequest.AddParameter("sign", signature);
    
            //execute the request
            var response = await client.Execute<JimiResponse<List<DeviceTrackListResponse>>>(webRequest);
    
            var responseData = response?.Data;
    
            if (response.StatusCode == HttpStatusCode.OK && responseData != null)
            {
                return responseData;
            }
            else
            {
                return new List<DeviceTrackListResponse>();
            }
        }
        catch (Exception ex)
        {
            return new List<DeviceTrackListResponse>();
        }
    }
