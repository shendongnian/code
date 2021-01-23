    using (ChannelFactory<IMyServiceChannel> factory = 
           new ChannelFactory<IMyServiceChannel>(new NetTcpBinding()))
          {
           using (IMyServiceChannel proxy = factory.CreateChannel(...))
           {
              using ( OperationContextScope scope = new OperationContextScope(proxy) )
              {
                 Guid myToken = Guid.NewGuid();
                 MessageHeader<Guid> mhg = new MessageHeader<Guid>(myToken);
                 MessageHeader untyped = mhg.GetUntypedHeader("token", "ns");
                 OperationContext.Current.OutgoingMessageHeaders.Add(untyped);
       
                 proxy.DoOperation(...);
              }
           }                    
        }
