    string mainURL = "https://trial.serviceobjects.com/AV3/api.svc/GetBestMatchesJson/" + businessName + "/" + address + "/" + address2 + "/" + city + "/" + state + "/" + zip + "/" + licenseKey;
    AV3Response result = null;
     
    HttpWebRequest request = WebRequest.Create(mainURL ) as HttpWebRequest;
    request.Timeout = 5000;//timeout for get operation
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
     if (response.StatusCode != HttpStatusCode.OK)
     throw new Exception(String.Format(
     "Server error (HTTP {0}: {1}).",
     response.StatusCode,
     response.StatusDescription));
     //parse response
     DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(AV3Response));
     object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
     result = objResponse as AV3Response;
    //processing result
    if (result.error == null)
    {
     //process result
    }
    else
    {
     //process error
    }
