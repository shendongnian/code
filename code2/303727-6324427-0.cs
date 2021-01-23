    public List<Client> AddClients(string strName)
    {
        List<Client> clients = new List<Client>();
        clients.Add(new Client()
        {
           Name = strName,
        });
        return clients;
    }
