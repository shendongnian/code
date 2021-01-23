    string responseText;
    using (WebResponse response = request.GetResponse())
    {
        Console.WriteLine (((HttpWebResponse)response).StatusDescription);
        using (Stream responseStream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(responseStream))
        {
            responseText = reader.ReadToEnd(responseText);
        }
    }
    Console.WriteLine(responseText);
