    var username = String.Empty;
    // using the namespace from you XML sample
    var usernameHeaderPosition = OperationContext.Current
        .IncomingMessageHeaders
        .FindHeader("username", "http://Microsoft.WCF.Documentation");
    
    if (usernameHeaderPosition > -1)
    {
        username = OperationContext.Current
            .IncomingMessageHeaders
            .GetReaderAtHeader(usernameHeaderPosition).ReadInnerXml();
    }
