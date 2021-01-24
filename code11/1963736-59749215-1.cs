    Clients = new ObservableCollection<Client>();
    foreach (string item in clients)
    {
        Client client = new Client(item);
     
        Clients.Add(client);
    
    }
