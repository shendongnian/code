    public static bool DoRemoteWebServiceWork()
    {
        bool result;
        RemoteWebServiceClient client = new RemoteWebServiceClient();
        try
        {
            result = client.DoWork();
            client.Close();
        }
        catch (Exception)
        {
            client.Abort(); //dispose
            //throw; //This service is auxiliary to the applications primary function. We have no influence over the service and therefore cannot fix it.
            //could log end point and binding exceptions to avoid ignoring changes to the remote service that require updates to our code.
        }
        return result;
    }
