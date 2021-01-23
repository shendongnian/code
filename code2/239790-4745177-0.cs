private ManualResetEvent _waitHandle = new ManualResetEvent(false);
private bool _timedOut;
...
    this._timedOut = false;
    this._waitHandle.Reset();
    HttpWebRequest request = HttpWebRequest.CreateHttp("http://cloudstore.blogspot.com");
    request.BeginGetResponse(this.GetResponse_Complete, request);
    bool signalled = this._waitHandle.WaitOne(5);
    if (false == signalled)
    {
        // Handle the timed out scenario.
        this._timedOut = true;
    }
    private void GetResponse_Complete(IAsyncResult result)
    {
        // Process the response if we didn't time out.
        if (false == this._timedOut)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            WebResponse response = request.EndGetResponse(result);
            // Handle response. 
         }
     }</code></pre>
Alternatively, you could use a third party library such as [Hammock][1], which enable syou to do timeouts and retry attempts (among other things). Depending on your project, that might be more than you need, though :)
 [1]: http://hammock.codeplex.com
