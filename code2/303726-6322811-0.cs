    public List<Client> AddClients( )
    {
        List<Client> clients = new List<Client>();
        clients.Add(new Client()
        {
           Name = new Name("myname"),
        });
        return clients;
    }
