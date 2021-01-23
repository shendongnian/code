    while (true)
    {
        var webRequest = (HttpWebRequest) WebRequest.Create("http://www.gooogle.com");
        Init(webRequest);
        using (var webResponse = (HttpWebResponse) webRequest.GetResponse())
        {
            using (var responseStream = webResponse.GetResponseStream())
            {
                responseStream.ReadTimeout = 30;
                using (var streamReader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    var page = streamReader.ReadToEnd();
                }
            }
            Console.WriteLine("Done");
        }
    }
