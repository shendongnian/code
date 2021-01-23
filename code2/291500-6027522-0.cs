    var msgEnum = blockingCollection.GetConsumingEnumerable();
    
    foreach( Message message in msgEnum )
    {
       //Process messages here
    }
