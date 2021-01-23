    using (ChannelFactory<IMyServiceChannel> factory = 
           new ChannelFactory<IMyServiceChannel>(new NetTcpBinding()))
          {
           using (IMyServiceChannel proxy = factory.CreateChannel(...))
           {
              using ( OperationContextScope scope = new OperationContextScope(proxy) )
              {
                 Guid apiKey = Guid.NewGuid();
                 MessageHeader<Guid> mhg = new MessageHeader<Guid>(apiKey);
                 MessageHeader untyped = mhg.GetUntypedHeader("apiKey", "ns");
                 OperationContext.Current.OutgoingMessageHeaders.Add(untyped);
       
                 proxy.DoOperation(...);
              }
           }                    
        }
