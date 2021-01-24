    int retryCount = 0
    while (retryCount < 5)
    {
      try
      {
        bool isUnique = false;
        string hawb = null;
        while(!isUnique)
        { 
          hawb = generateHawb();
          isUnique = context.HawbAssets.Any(x => x.HAWB == hawb);
        }
        entity.HAWB = hawb; // this hawb should be unique, so set and insert.
        _repository.Insert(entity);
      }
      catch(UpdateException)
      {
      // log that this has happened, check inner exception for duplicate key and retry, though limit retry attempts if there are deeper issues that might lock up the system in a retry loop.
        retryCount++;
      }
    }
