    var request = (HttpWebRequest)WebRequest.Create("http://stackoverflow.com/1");
    try
    {
        using (WebResponse response = request.GetResponse())
        {
            // Success
        }
    }
    catch (WebException e)
    {
        using (WebResponse response = e.Response)
        {
            HttpWebResponse httpResponse = (HttpWebResponse)response;
            Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
            using (var streamReader = new StreamReader(response.GetResponseStream()))
                Console.WriteLine(streamReader.ReadToEnd());
        }
    }
