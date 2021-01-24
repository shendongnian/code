    private async void button1_Click(object sender, EventArgs e)
    {
        List<string> urls = new List<string>
        {
            "https://www.google.com.mx",
            "https://www.google.com.mx",
            "https://www.google.com.mx",
            "https://www.google.com.mx",
        };
        var tasks = new List<Task>();
        var results = new List<string>();
        foreach (string url in urls)
        {
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            CookieContainer gaCookies = new CookieContainer();
            gaCookies.Add(new Cookie("dosid", textBox1.Text) { Domain = /*target.Host*/ "google.com" });
            webReq.CookieContainer = gaCookies;
            tasks.Add(GetURLContentsAsync(webReq));
        }
        await Task.WhenAll(tasks); //wait for all the urls to finish loading
        foreach (Task<string> task in tasks) //get the results of all the web requests
        {
            results.Add(await task);
        }
    }
    private async Task<string> GetURLContentsAsync(HttpWebRequest webReq)
    {
        var content = new MemoryStream();
        using (WebResponse response = await webReq.GetResponseAsync())
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                await responseStream.CopyToAsync(content);
            }
        }
        var buffer = content.ToArray();
        return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
    }
