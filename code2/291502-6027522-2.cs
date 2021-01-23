    var msgEnum = blockingCollection.GetConsumingEnumerable();
    
    //Per thread
    foreach( Message message in msgEnum )
    {
       //Process messages here
    }
