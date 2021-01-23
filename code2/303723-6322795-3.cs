    public List<Client> AddClients(IEnumerable<string> names)
    {
        List<Client> clients = new List<Client>();
    
        foreach(var name in names)
        {
            clients.Add(new Client()
            {
               Name = name,
            });
        }
        
        return clients;
    }
