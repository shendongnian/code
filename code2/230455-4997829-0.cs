    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request["signed_request"]))
        {
            string signed_request = Request["signed_request"];
            Dictionary<string, Facebook.JSONObject> jsonDict = new Dictionary<string, Facebook.JSONObject>();
            if (Helper.FacebookAPI.ValidateSignedRequest(signed_request, out jsonDict))
            {
                if (jsonDict.ContainsKey("user_id"))
                {
                    long FacebookId = jsonDict["user_id"].Integer;
                    // delete code
                }
            }
        }
    }
