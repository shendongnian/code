    private void StartWebRequest(string url, string filename)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.BeginGetResponse(result => {
            FinishWebRequest(result, request, filename);
        }, null); // Don't need the state here any more
    }
    private void FinishWebRequest(IAsyncResult result,
                                  HttpWebRequest request,
                                  string filename)
    {
        using (HttpWebResponse response =
                 (HttpWebResponse) request.EndGetResponse(result))
        {
            // Use filename here
        }
    }
