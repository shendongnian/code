    var client = new RestClient(mServer);
    var request = new RestRequest(Method.POST);
    request.AddQueryParameter("action", "GET");
    IRestResponse response = client.Execute(request);
    string mResponse = response.Content;
    
    mUser = new JObject();
    mUser = JObject.Parse(mResponse);
    string mStatus = mUser["status"].ToString();
    if (mStatus.Equals("DONE")
    {
        MessageBox.Show("Status: DONE");
    }
