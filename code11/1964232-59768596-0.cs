    public string GetClientIp()
    {
      OperationContext operationContext = OperationContext.Current;
      MessageProperties messageProps = operationContext.IncomingMessageProperties;
      RemoteEndpointMessageProperty endpointProps = (RemoteEndpointMessageProperty)messageProps[RemoteEndpointMessageProperty.Name];
    
      return endpointProps.Address;
    }
