    private void ScanSites ()
    {
      // for each URL in the collection...
      WebRequest request = HttpWebRequest.Create(uri);
    
      // RequestState is a custom class to pass info
      RequestState state = new RequestState(request, data);
    
      IAsyncResult result = request.BeginGetResponse(
        new AsyncCallback(UpdateItem),state);
    }
    
    private void UpdateItem (IAsyncResult result)
    {
      // grab the custom state object
      RequestState state = (RequestState)result.AsyncState;
      WebRequest request = (WebRequest)state.request;
      // get the Response
      HttpWebResponse response =
        (HttpWebResponse )request.EndGetResponse(result);
      
      // fire the event that notifies the UI that data has been retrieved...
    }
