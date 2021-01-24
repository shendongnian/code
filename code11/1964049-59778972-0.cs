    ConcurrentDictionary<Guid, bool> Status = new ConcurrentDictionary<Guid, bool>();
    
    while (ItemsTypes.Values.Count() > 0)
    {
        foreach (var item in ItemsTypes)
        {
          if (item.Value.Count > 0)
          {
            if (Status[issuer.Key] == false)
            {
              Status[issuer.Key] = true;
              Task.Run(() => ProcessItems(item.Value.Dequeue()));
             }
           }
         }
      }
  
