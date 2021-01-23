    private byte[] DownloadBits(WebRequest request, Stream writeStream, CompletionDelegate completionDelegate, AsyncOperation asyncOp)
    {
        WebResponse response = null;
        DownloadBitsState state = new DownloadBitsState(request, writeStream, completionDelegate, asyncOp, this.m_Progress, this);
        if (state.Async)
        {
            request.BeginGetResponse(new AsyncCallback(WebClient.DownloadBitsResponseCallback), state);
            return null;
        }
        response = this.m_WebResponse = this.GetWebResponse(request);
        int bytesRetrieved = state.SetResponse(response);
        while (!state.RetrieveBytes(ref bytesRetrieved))
        {
        }
        state.Close();
        return state.InnerBuffer;
    }
    
