        class HttpRequest<T>
    {
        internal HttpRequest(HttpWebRequest webRequest, Action<T> callback)
        {
            WebRequest = webRequest;
            Callback = callback;
        }
        internal HttpWebRequest WebRequest { get; private set; }
        internal Action<T> Callback { get; private set; }
    }
    class Class1
    {
        private Uri _url;
        private string _action;
        private string _postData;
        public void PostMethodResponse(Action<string> callback)
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(_url);
                myRequest.Method = "POST";
                myRequest.Headers["SOAPAction"] = _action;
                myRequest.ContentType = "text/xml; charset=utf-8";
                myRequest.Accept = "text/xml";
                myRequest.BeginGetRequestStream(GetRequestStreamCallback, new HttpRequest<string>(myRequest, callback));
            }
            catch (Exception ex)
            {
                // log blah
            }
        }
        private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpRequest<string> request = (HttpRequest<string>)asynchronousResult.AsyncState;
                System.IO.Stream postStream = request.WebRequest.EndGetRequestStream(asynchronousResult);
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(_postData);
                postStream.Write(byteArray, 0, byteArray.Length);
                postStream.Close();
                // Start the asynchronous operation to get the response
                request.WebRequest.BeginGetResponse(GetResponseCallback, request);
            }
            catch (Exception ex)
            {
                // nothing to see, move along
            }
        }
        private void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpRequest<string> request = (HttpRequest<string>)asynchronousResult.AsyncState;
                HttpWebResponse response = (HttpWebResponse)request.WebRequest.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                if (streamResponse != null)
                {
                    StreamReader streamRead = new StreamReader(streamResponse);
                    string responseString = streamRead.ReadToEnd();
                    // Close the stream object
                    streamResponse.Close();
                    streamRead.Close();
                    // Release the HttpWebResponse
                    response.Close();
                    request.Callback(responseString);
                }
            }
            catch (Exception )
            {
            }
        }
    }
