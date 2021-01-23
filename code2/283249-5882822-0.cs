    // Global definition of Client dictionary
    // The first argument within <> is the key type, the second argument
    // is the type of object that key will map to
    Dictionary<int, StateObject> Clients = new Dictionary<int, StateObject>();
    // Accept client callback
    public static void AcceptCallback(IAsyncResult ar)
    {
        // Get the socket that handles the client request.
        Socket listener = (Socket) ar.AsyncState;
        Socket handler = listener.EndAccept(ar);
        
        StateObject client = new StateObject();
        
        // Then set all the variables of client here
        Clients.Add(ID, client);
    }
