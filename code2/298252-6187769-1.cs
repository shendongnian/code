    [WebMethod]
    public SendMessageResponse SendMessage(...)
    {
        var response = new SendMessageResponse();
    
        try
        {
            // Do your send message stuff here...
            response.Successful = true; // or whatever you want to say
        }
        catch( Exception ex )
        {
            response.ProcessException( ex );
        }
    
        return response;
    }
