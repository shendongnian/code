    using (HttpClient httpclient = new HttpClient()) 
    {
        Models.ApplicationUser applicationUser = new ApplicationUser();
        string serialized = Newtonsoft.Json.JsonConvert.SerializeObject(applicationUser);
        StringContent stringContent = new StringContent(serialized);
        httpclient.PostAsync("url", stringContent);
    }
