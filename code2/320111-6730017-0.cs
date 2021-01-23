    private ServiceClient proxy;
    try
    {
        proxy = new ServiceClient("ConfigName", "http://serviceaddress//service.svc");
        string result = proxy.Method();
        proxy.Close();    
    }
    catch (CommunicationException e)
    {
       proxy.Abort();
    }
    catch (TimeoutException e)
    {
       proxy.Abort();
    }
    catch (Exception e)
    {
       // ...
       proxy.Abort();
       throw;
    }
