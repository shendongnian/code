    public void AddClients(List<Client> clients, string name)
    {
        clients.Add(new Client()
        {
           Name = name,
        });
        return clients;
    }
