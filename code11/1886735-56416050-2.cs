    WebClient webclient = new WebClient();
    webclient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webclient_DownloadStringCompleted);
    webclient.DownloadStringAsync(new Uri("http://ws.phpurl.com/?password=stackoverflow@12345"));
    
    void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        string phpWsEncryptedPass = e.Result;
        string databaseEncryptedPass = //TO DO: query Database
                                       //using WHERE statement,
                                       //parsing 'phpWsEncryptedPass' as parameter;
    }
