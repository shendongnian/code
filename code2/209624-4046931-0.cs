    try
    {
        request = (HttpWebRequest)asynchronousResult.AsyncState;
        response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
    }
    catch (Exception e)
    {
        Debug.WriteLine("Got Exception in GetResponseCallback: " + e.Message);
    }
    allDone.Set();
