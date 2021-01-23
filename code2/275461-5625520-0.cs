    var req = (HttpWebRequest)iAreq;
    bool iWantInToo = true;
    req.BeginGetResponse(new AsyncCallback(iEndGetResponse), Tuple.Create(req, iWantInToo));
    //Method
    private void iEndGetResponse(IAsyncResult iA) 
    {
        Tuple<HttpWebRequest, bool> state = (Tuple<HttpWebRequest, bool>)iA.AsyncState;
        bool iWantInToo = state.Item2;
        // use values..
    }
