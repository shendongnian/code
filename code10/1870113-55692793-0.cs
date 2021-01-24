    using Newtonsoft.Json; 
    static public ModelClass GetProfile()
    {
        string url = "http://localhost:50121/api/Profile/1";
        var client = new WebClient();
        //object serialised as json string
        var content = client.DownloadString(url);
        //object deserialised as ModelClass
        var model = JsonConvert.DeserializeObject<ModelClass>(json);
        return model;
    }
