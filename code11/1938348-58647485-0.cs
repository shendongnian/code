    private void startConnectionThread()
    {
        new Thread(async() =>
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(200);
            while (true)
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://192.168.0.177/");
                    strResult = await response.Content.ReadAsStringAsync();
                    handleResult(strResult);
                }
                catch (Exception ex)
                {
                }
            }
        }).Start();
    }
