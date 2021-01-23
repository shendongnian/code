          // Following line gives error, as it should do, because the .NET types 
          // MyClient.IService and MySpace.Service are not related.   
          MyClient.IService iservice = (MyClient.IService)new MySpace.Service();   // ERROR !!
          // Likewise, a WCF client proxy defined using MyService.IService as the contract
          // cannot be cast to the unrelated .NET type MyClient.IService
          ChannelFactory<MyService.IService> fac = new ChannelFactory<MyService.IService>(binding); 
          fac.Open(); 
          MyClient.IService proxy = (MyClient.IService)fac.CreateChannel(new EndpointAddress(Url));  // ERROR !!
 
          // but the service can be consumed by any WCF client proxy for which the contract 
          // matches the defined service contract (i.e. they both expect the same XML infoset 
          // in the request and response messages). There is no dependency between the .NET type 
          // used in the client code and the .NET type used to implement the service. 
          ChannelFactory<MyClient.IService> fac = new ChannelFactory<MyClient.IService>(binding); 
          fac.Open(); 
          // Next line does not error because the ChannelFactory instance is explicitly 
          // specialised to return a MyClient.IService so the .NET type is the same... there is no cast
          MyClient.IService proxy = fac.CreateChannel(new EndpointAddress(Url)); 
