    public void Subscribe(string clientID, Uri uri)
    {
        using(clientsDBDataContext clientDB = new clientsDBDataContext())
        {
            var existingClient = (from c in clientDB.clientURIs
                                  where c.clientID == clientID
                                  select c).SingleOrDefault();
            if(existingClient == null)
            {
                // This is a new record that needs to be added
                var client = new ServiceFairy.clientURI();
                client.clientID = clientID;
                client.uri = uri.ToString();
                clientDB.clientURIs.InsertOnSubmit(client);
            }
            else
            {
                // This is an existing record that needs to be updated
                existingClient.uri = uri.ToString();
            }
            clientDB.SubmitChanges();
        }
    }
