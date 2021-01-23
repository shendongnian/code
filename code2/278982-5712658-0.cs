    ServiceContractClient proxy = new ServiceContractClient();
    using (OperationContextScope scope = new OperationContextScope((IContextChannel)proxy.InnerChannel))
    {
        MessageHeaders messageHeadersElement = OperationContext.Current.OutgoingMessageHeaders;
        messageHeadersElement.Add(MessageHeader.CreateHeader("username", String.Empty,
            System.Security.Principal.WindowsIdentity.GetCurrent().Name)); 
        var res = proxy.CallWCFMethod();
    }
