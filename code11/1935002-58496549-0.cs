    public ICollection<ConnectionHandler> GetConnectedClients(long tableId)
    {
    
       var results = _gameTableEntries.Where(x => x.TableId == tableId)
                                      .SelectMany(x => x.ConnectedClients)
                                      .Where(x => x.IsConnected);
    
       return new HashSet<ConnectionHandler>(results);
    
    }
