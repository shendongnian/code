    public void SendThat(MailMessage message)
    {
        AsyncMethodCaller caller = new AsyncMethodCaller(SendMailInSeperateThread);
        AsyncCallback callbackHandler = new AsyncCallback(AsyncCallback);
        caller.BeginInvoke(message, callbackHandler, null);
    }
    private delegate void AsyncMethodCaller(MailMessage message);
    private void SendMailInSeperateThread(MailMessage message)
    {
        try
        {
            SmtpClient client = new SmtpClient();
            client.Timeout = 20000; // 20 second timeout... why more?
            client.Send(message);
            client.Dispose();
            message.Dispose();
            // If you have a flag checking to see if an email was sent, set it here
            // Pass more parameters in the delegate if you need to...
        }
        catch (Exception e)
        {
             // This is very necessary to catch errors since we are in
             // a different context & thread
             Elmah.ErrorLog.GetDefault(null).Log(new Error(e));
        }
    }
    private void AsyncCallback(IAsyncResult ar)
	{
		try
		{
			AsyncResult result = (AsyncResult)ar;
			AsyncMethodCaller caller = (AsyncMethodCaller)result.AsyncDelegate;
			caller.EndInvoke(ar);
		}
		catch (Exception e)
		{
		    Elmah.ErrorLog.GetDefault(null).Log(new Error(e));
			Elmah.ErrorLog.GetDefault(null).Log(new Error(new Exception("Emailer - This hacky asynccallback thing is puking, serves you right.")));
		}
	}
