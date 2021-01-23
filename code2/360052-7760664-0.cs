    protected void Page_Load(object sender, EventArgs e)
            {
                HttpWebRequest req;
    
                req = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", pageUrl.ToString(), arguments));
                req.Method = "GET";
    
                // pass in request so we can retrieve it later
                req.BeginGetResponse(new AsyncCallback(RespCallback), req); 
    
            }
    
            void RespCallback(IAsyncResult result)
            {
                HttpWebRequest originalRequest = (HttpWebRequest)result.AsyncState;
                HttpWebResponse response = (HttpWebResponse)originalRequest.EndGetResponse(result);
    
                // response.GetResponseStream()
            }
