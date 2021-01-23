    using(WebClient client = new WebClient())
    {
        System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
        reqparm.Add("param1", "<any> kinds & of = ? strings");
        reqparm.Add("param2", "escaping is already handled");
        byte[] responsebytes = client.UploadValues("http://localhost", "POST", reqparm);
        string responsebody = Encoding.UTF8.GetString(responsebytes);
    }
