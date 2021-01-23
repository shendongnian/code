    static List<ClientState> _clientStates;
    static readonly Object _clientStatesLock = new Object();
    
    /// Gets the state of a client for a given Id.
    /// Returns null if no state exists.
    /// This method is threadsafe.
    ClientState GetState (ClientIdentifier id){
        lock (_clientStatesLock)
            return  _clientStates.FirstOrDefault (cs => cs.Id == id);
    }
