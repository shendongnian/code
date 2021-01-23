    var uri = new Uri("http://www.google.com");
    var client = new WebClient();
    while(true)
    {
        try
        {
            var data = client.DownloadData(uri);
            Console.WriteLine("Downloaded {0:N0} bytes.", data.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
