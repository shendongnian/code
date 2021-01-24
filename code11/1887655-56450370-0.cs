    public void CreateReport(int ClientID)
    {
        ClientModel client = DataConfig.Connection.GetClientByID(ClientID).FirstOrDefault();
        string ClientName = (client.FName + " " + client.MName + " " + client.LName).ToUpper();
        string ClientNameFooter = client.FName + " " + client.MName + " " + client.LName;
    
        Debug.WriteLine("ClientName: {0}", ClientName);
        Debug.WriteLine("ClientNameFooter: {0}", ClientNameFooter);
    }
