    string queryTimeStamp = Request.QueryString["t"];
    Int64 queryCallerID;
    Int64.TryParse(Request.QueryString["s"] == string.Empty ? "0" : Request.QueryString["s"], out queryCallerID);
    int querySMSGateway;
    Int32.TryParse(Request.QueryString["d"] == string.Empty ? "0" : Request.QueryString["d"], out querySMSGateway);
    string querySMSMessage = Request.QueryString["m"];
