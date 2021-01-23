    private readonly object clientsLock = new object();
    private Client[] clients = new Client[0];  
    
    public CreateClients(int count) {     
      lock (clientsLock) {         
        clients = new string[count]; 
        ...
      }
    }
