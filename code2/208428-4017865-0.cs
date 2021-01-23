       string webServ = "addressofwebservice";
       AsyncCallback asyncCall = new AsyncCallback(CallBack);
       webServ.BeginSomeFunkyMethod(data, asyncCall, webServ);
...
    private void CallbackSampleMethod(IAsyncResult asyncResult)
    {
       if(asyncResult != null)
       {
           doFunkyStuff();
       }
       // else I really don't care...
    }
