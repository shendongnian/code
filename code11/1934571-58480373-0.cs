    using (WebClient client = new WebClient())
    {
        try
        {
            string data = client.DownloadString("https://localhost:44357/weatherforecast");
        }
        catch (WebException ex)
        {
            using (StreamReader r = new StreamReader(ex.Response.GetResponseStream()))
            {
                string response = r.ReadToEnd(); // access the reponse message
            }
        }
    }
