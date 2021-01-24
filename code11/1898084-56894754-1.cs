     public ObservableCollection<Client> Source
        {
            get
            {   
                daClient daClient = new daClient();
                ObservableCollection<Client> clients = new ObservableCollection<Client>(daClient.GetClients((Application.Current as App).ConnectionString))
                {
                    //This works the same as using clients.Add(newClientRow()); - just put it inside the curly bracked when initializing the ObservableCollection. 
                    newClientRow()
                };
                return clients;
            }
        }
