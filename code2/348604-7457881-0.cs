    IASyncResult res = Proxy.BeginMethod(endCall,null);
    ThreadPool.QueueUserWorkItem(a=>
    {
        res.EndMethod();
        try
        {
            Proxy.Close();
        }
        catch (CommunicationException e)
        {
            Proxy.Abort();
        }
        catch (TimeoutException e)
        {
            Proxy.Abort();
        }
        catch (Exception e)
        {
            Proxy.Abort();
        }
    });
