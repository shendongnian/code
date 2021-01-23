    while (true)
    {
        WebRequest http = WebRequest.Create("http://www.sina.com.cn");
        using (HttpWebResponse response = (HttpWebResponse)http.GetResponse())
        {
            Console.WriteLine(response.LastModified);
        }
        Thread.Sleep(5000);
    }
