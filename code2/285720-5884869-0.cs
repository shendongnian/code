    private Client client;
    public Client Client
    {
      get
      {
        if (client == null)
          client = new Client();
    
        return client;
      }
    }
