    public WebrequestExample()
        {
            string url = "COPY YOUR URL HERE";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            
            // ...
            // Different settings, like content type or method...
            // ...
            request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
        }
        public void GetRequestStreamCallback(IAsyncResult asyncResult)
        {
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
            Stream postStream = request.EndGetRequestStream(asyncResult);
            // Data writing
            // ...
            // postStream.Write(...)
            // ...
            // Start the async operation to get the response
            request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }
        public void GetResponseCallback(IAsyncResult asyncResult)
        {
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult); // Get the HttpWebResponse
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    // Do something with the response
                }
            }
        }
