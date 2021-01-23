    void SendRequest()
    {
        WebClient wc = new WebClient();
        wc.DownloadStringAsync(new Uri("http://somesite.com/webservice"));
        wc.DownloadStringCompleted +=DownloadStringCompleted;
    }
 
    void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        Debug.WriteLine("Web service says: " + e.Result);
    }
