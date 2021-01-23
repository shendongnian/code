    private void Callback(IAsyncResult ar)
    {
         AsyncResult asyncResult = (AsyncResult)ar;
         Func<string, objectA> d = (Func<string, objectA>)asyncResult.AsyncDelegate;
         objectA result = d.EndInvoke(ar);
    }
