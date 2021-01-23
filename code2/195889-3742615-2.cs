    // sending image to server as base 64 string
    string imageBase64String = "YTM0NZomIzI2OTsmIzM0NTueYQ...";
    using (WebClient client = new WebClient())
    {
        var values = new NameValueCollection();
        values.Add("image", imageBase64String);
        client.UploadValues("http://192.168.1.2/", values);
    } 
