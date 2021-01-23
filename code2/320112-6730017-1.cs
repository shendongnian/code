    private ServiceClient proxy;
    try
    {
        proxy = new ServiceClient("ConfigName", "http://serviceaddress//service.svc");
        string result = proxy.Method();
        proxy.Close();    
    }
    catch (CommunicationException e)
    {
       // possibly log error, possibly clean up
       proxy.Abort();
    }
    catch (TimeoutException e)
    {
       // possibly log error, possibly clean up
       proxy.Abort();
    }
    catch (Exception e)
    {
       // possibly log error, possibly clean up
       proxy.Abort();
       throw;
    }
