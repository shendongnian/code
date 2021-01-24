    WebClient client = new WebClient();
    string uri = "API_URI";
    var reqparm=new NameValueCollection(); // Used for passing request perameter
    reqparm.Add("some","json data");
    response = Encoding.UTF8.GetString(client.UploadValues(uri, "POST", reqparm));
