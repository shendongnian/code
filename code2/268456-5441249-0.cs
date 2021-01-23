    private void HandlerWebResponse(IAsyncResult asynchronousResult)
    {
        HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
        using (StreamReader streamReader1 = new StreamReader(response.GetResponseStream()))
        {
            string resultString = streamReader1.ReadToEnd();
            if (ResponseResult != null)
                 ResponseResult(resultString);
    
        }
    }
