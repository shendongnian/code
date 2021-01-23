    for (int i = 0; i < OperationContext.Current.IncomingMessageHeaders.Count; ++i)
    {
        MessageHeaderInfo h = OperationContext.Current.IncomingMessageHeaders[i];
        // for any reference parameters with the correct name & namespace
        if (h.IsReferenceParameter && 
            h.Name == IDName && 
            h.Namespace == IDNamespace) 
        {
            // read the value of that header
            XmlReader xr = OperationContext.Current.IncomingMessageHeaders.GetReaderAtHeader(i);
            id = xr.ReadElementContentAsString();
        }
    }
