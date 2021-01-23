    int myTicket = accessTicket;
    
    lock (threadLock)
    {
        if (myTicket == accessTicket)
        {
            ++accessTicket;
            //get collection of entities using Fluent NHib
            //add collection to cache
        }
    }
