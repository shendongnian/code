    // wc: WebConsumer
    var calRequest = wc.PrepareAuthorizedRequest(erp2, authTokenRsp.AccessToken);
    // need to stop redirect to capture calendar cookie token:
    calRequest.AllowAutoRedirect = false;
    var calResponse = calRequest.GetResponse();
    var redirectCookie = calResponse.Headers[System.Net.HttpResponseHeader.SetCookie];
    var cookiedCalRequest = wc.PrepareAuthorizedRequest(erp2, authTokenRsp.AccessToken);
    cookiedCalRequest.Headers[System.Net.HttpRequestHeader.Cookie] = redirectCookie;
    var calFeedResponse = cookiedCalRequest.GetResponse();
