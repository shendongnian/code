    [System.Web.Services.WebMethod]
    public static bool WebMethodName(string input)
    {
        try
        {
            //do something here with the input
        
            return (true);
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
