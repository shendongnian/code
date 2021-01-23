    public class StringEventArgs : EventArgs
    {
       public string Message { get; set; }
    }
    
    public event EventHandler<StringEventArgs> MessageReturned;
    
    public void GetMessageAsync()
    {
        //string messageToReturn = string.empty;
        request.BeginGetResponse(ar => 
                { 
                    HttpWebRequest req2 = (HttpWebRequest)ar.AsyncState; 
                    var response = (HttpWebResponse)req2.EndGetResponse(ar);
                    
                    //messageToReturn = "base on respone, assign different message"; 
                    this.MessageReturned(this, new StringEventArgs { Message = response.ToString() });
    
                }, request);
    }
