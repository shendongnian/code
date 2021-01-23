    using (OperationContextScope scope = new OperationContextScope(cli.InnerChannel))
    {
       OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("MyHeader", Guid.NewGuid().ToString(), ""));
                    
       string ret = cli.GetData(1);
    }
