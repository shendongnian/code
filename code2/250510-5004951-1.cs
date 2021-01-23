    switch(toResponse.Ack)
    {
    case AckCodeType.Failure;
         // The card is bad. void transaction.
         lblResponse = toResponse.Errors[0].LongMessage;
         Break;
    case AckCodeType.Success
         // The card is good.  Go forward with process
    }
