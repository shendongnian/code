    public void GetMessageAsync()
    {
        string messageToReturn = string.empty;
        request.BeginGetResponse(ar => 
                { 
                    HttpWebRequest req2 = (HttpWebRequest)ar.AsyncState; 
                    var response = (HttpWebResponse)req2.EndGetResponse(ar);
    
                    // is it safe to do this?
                    messageToReturn = "base on respone, assign different message"; 
    
    
                }, request);
    }
