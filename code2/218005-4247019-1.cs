    client = new ServiceClient1();
    OperationContextScope scope = new OperationContextScope(client.InnerChannel));
    OperationContext.Current.OutgoingMessageProperties.Add("ChannelId", Guid.NewGuid().ToString());
    string ret = client.GetData(1);
    
