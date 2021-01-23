    private void ResponseCallback(IAsyncResult asynchronousResult)
    {
        var request = (HttpWebRequest)asynchronousResult.AsyncState;
        using (var resp = (HttpWebResponse)request.EndGetResponse(asynchronousResult))
        {
            using (var streamResponse = resp.GetResponseStream())
            {
                using (var streamRead = new StreamReader(streamResponse))
                {
                    string responseString = streamRead.ReadToEnd();  // Assuming that the server will send a text based indication of upload success
                    // act on the response as appropriate
                }
            }
        }
    }
