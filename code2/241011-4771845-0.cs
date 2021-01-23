    private readonly object myLock = new object();
    private Dictionary<int> assignedKeys = new Dictionary<int>();
    ...
    
    lock(myLock)
    {
      int key = PickAKeyHere();
      AssignKeyToClient(key, clientId);
      assignedKeys[key] = clientId; //keep track of which client is assigned what key 
    }
