    var inputs = new NameValueCollection();
    inputs.Add("field1", "value1");
    inputs.Add("field2", "value2");
    inputs.Add("field3", "value3");
    System.Net.WebClient Client = new WebClient();
    Client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
    byte[] POSTResultData = Client.UploadValues(postUrl, inputs);
