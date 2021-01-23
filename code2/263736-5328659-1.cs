    private static readonly object clientsLock = new object();
    private static string[] Clients = null;
    
    public CreateClients(int count)
    {
        if(clients == null)
        {
            lock (clientsLock)
            {
                if(clients == null)
                {
                    clients = new string[count];
    
                    for(int i=0; i<count; i++)
                    {
                         client[i] = new Client();//Stripped
                    }
                }
            }
         }
     }
