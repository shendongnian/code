    try 
    {
        try 
        {
            proxy.call();
            //app logic
            ((ICommunicationObject)proxy).Close();
        } 
        catch (SomeAppException)
        {
        //recover app exception
        }
    }
    catch (CommunicationException) 
    {
        ((ICommunicationObject)proxy).Abort();
    }
