    HttpWebResponse response = null;
    try
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(<your URL here>);
        response = (HttpWebResponse)request.GetResponse();
        Stream responseStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(responseStream);
        //use the StreamReader object to get the page data and parse out the title as well as
        //getting locations of any images you need to get
    catch
    {
        //handle exceptions
    }
    finally
    {
        if(response != null)
        {
            response.Close();
        }
    }
