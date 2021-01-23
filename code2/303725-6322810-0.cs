    public List<Client> AddClients(List<Client> clients )
    {
        clients.Add(new Client()
        {
           Name = "MyName",
        });
        return clients;
    }
 
