    public void CreateReport(int ClientID)
    {
        try
        {
             ClientModel client = DataConfig.Connection.GetClientByID(ClientID).FirstOrDefault();
             
             if(client != null)
             {
                 string ClientName = (client.FName + " " + client.MName + " " + client.LName).ToUpper();
                 string ClientNameFooter = client.FName + " " + client.MName + " " + client.LName;
                 Debug.WriteLine("ClientName: {0}", ClientName);
                 Debug.WriteLine("ClientNameFooter: {0}", ClientNameFooter);
             }
             else
             {
                 Debug.WriteLine("Couldn't find a client with that Id...");
             }
        }
        catch (Exception ex)
        {
             throw new Exception(ex.Message);
        }
    }
