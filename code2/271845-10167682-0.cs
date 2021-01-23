    public IAsyncResult BeginPostData(string url, string content, AsyncCallback callback, object state)
    {
        var ae = new AsyncEnumerator<string>();
        return ae.BeginExecute(PostData(ae, url, content), callback, state);
    }
    public string EndPostData(IAsyncResult result)
    {
        var ae = AsyncEnumerator<string>.FromAsyncResult(result);
        return ae.EndExecute(result);
    }
    private IEnumerator<int> PostData(AsyncEnumerator<string> ae, string url, string content)
    {
        var req = (HttpWebRequest)WebRequest.Create(url);
        req.Method = "POST";
        req.BeginGetRequestStream(ae.End(), null);
        yield return 1;
        using (var requestStream = req.EndGetRequestStream(ae.DequeAsyncResult()))
        {
            var bytes = Encoding.UTF8.GetBytes(content);
            requestStream.BeginWrite(bytes, 0, bytes.Length, ae.end(), null);
            yield return 1;
            requestStream.EndWrite(ae.DequeueAsyncResult());
        }
        req.BeginGetResponse(ae.End(), null);
        yield return 1;
        using (var response = req.EndGetResponse(ae.DequeueAsyncResult()))
        using (var responseStream = response.GetResponseStream())
        using (var reader = new StreamReader(responseStream))
        {
            ae.Result = reader.ReadToEnd();
        }
    }
