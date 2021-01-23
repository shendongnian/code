    public class WebRequesterHelper
    {
      Action _callback;
    
      public void MakeWebRequest(object whateverYouNeedForTheWebRequest, Action callback)
      {
        _callback = callback;
    
        //Make your async web request here, passing the helper object's callback.
        IAsyncResult result = yourWebRequestObject.BeginGetResponse(new AsyncResultCallback(WebRequestCallback), yourRequestState);
      }
    
      public void WebRequestCallback(IAsyncResult result)
      {
        //Do whatever you need to do as a result of the web request, then call the callback.
        if (_callback != null) callback();
      }
    }
