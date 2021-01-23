    public bool InsertClient(Client client)
    {
       if(client.ClientID > 0)
          return;
    
       dc.Clients.InsertOnSubmit(client);
    
       try
       {
          dc.SubmitChanges();
          return true;
       }
       catch
       {
            return false;
       }
    }
